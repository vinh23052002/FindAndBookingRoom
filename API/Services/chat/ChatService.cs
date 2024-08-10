using API.Dtos.Chat;
using API.Exceptions;
using API.Models;
using API.Repositoriest.chat;
using API.Repositoriest.room;
using API.Response;
using AutoMapper;
using System.Net;

namespace API.Services.chat
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;

        public ChatService(IChatRepository chatRepository, IMapper mapper, IRoomRepository roomRepository)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
            _roomRepository = roomRepository;
        }

        public async Task<SuccessResponse> CreateMessage(ChatRequest request)
        {
            if (request == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Request null");
            };

            if (await _roomRepository.GetById(request.roomID) == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Room not found");
            }

            var message = _mapper.Map<Chat>(request);
            message.reviewDate = DateTime.Now;
            await _chatRepository.Add(message);
            return new SuccessResponse
            {
                Message = "Create Message Successfully",
                Data = _mapper.Map<ChatResponse>(message)
            };
        }

        public async Task<SuccessResponse> GetMessage(int id)
        {
            var message = await _chatRepository.GetById(id);
            return new SuccessResponse
            {
                Message = "Get Message Successfully",
                Data = _mapper.Map<ChatResponse>(message)
            };
        }

        public async Task<SuccessResponse> GetMessageByRoomID(int roomID)
        {
            var messages = await _chatRepository.GetReviewsByRoomID(roomID);
            var response = _mapper.Map<List<ChatResponse>>(messages);
            return new SuccessResponse
            {
                Message = "Get Message By RoomID Successfully",
                Data = response
            };
        }
        //public async Task<SuccessResponse> GetTotalByUserID(string userID)
        //{
        //    var messages = await _chatRepository.GetMessageByUserID(userID);
        //    return new SuccessResponse
        //    {
        //        Message = "Get Total Message By UserID Successfully",
        //        Data = messages.Count
        //    };
        //}

        public async Task<SuccessResponse> DeleteMessage(int id)
        {
            await _chatRepository.Delete(id);
            return new SuccessResponse
            {
                Message = "Delete Message Successfully",

            };
        }

        //public async Task<SuccessResponse> changeStatus(int id)
        //{
        //    var message = await _chatRepository.GetById(id);
        //    message.isRead = true;
        //    await _chatRepository.Update(message);
        //    return new SuccessResponse
        //    {
        //        Message = "Change Status Successfully",
        //        Data = _mapper.Map<MessageResponse>(message)
        //    };
        //}

    }
}
