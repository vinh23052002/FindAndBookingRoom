using API.Dtos.Message;
using API.Exceptions;
using API.Models;
using API.Repositoriest.message;
using API.Repositoriest.room;
using API.Response;
using AutoMapper;
using System.Net;

namespace API.Services.message
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;

        public MessageService(IMessageRepository messageRepository, IMapper mapper, IRoomRepository roomRepository)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _roomRepository = roomRepository;
        }

        public async Task<SuccessResponse> CreateMessage(MessageRequest request)
        {
            if (request == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Request null");
            };

            if (await _roomRepository.GetById(request.roomID) == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Room not found");
            }

            var message = _mapper.Map<Message>(request);
            message.sendDate = DateTime.Now;
            message.isRead = false;
            await _messageRepository.Add(message);
            return new SuccessResponse
            {
                Message = "Create Message Successfully",
                Data = _mapper.Map<MessageResponse>(message)
            };
        }

        public async Task<SuccessResponse> GetMessage(int id)
        {
            var message = await _messageRepository.GetById(id);
            return new SuccessResponse
            {
                Message = "Get Message Successfully",
                Data = _mapper.Map<MessageResponse>(message)
            };
        }

        public async Task<SuccessResponse> GetMessageByUserID(string userID)
        {
            var messages = await _messageRepository.GetMessageByUserID(userID);
            var response = _mapper.Map<List<MessageResponse>>(messages);
            foreach (var message in response)
            {
                message.roomName = _roomRepository.GetById(message.roomID).Result.name;
            }
            return new SuccessResponse
            {
                Message = "Get Message By UserID Successfully",
                Data = response
            };
        }
        public async Task<SuccessResponse> GetTotalByUserID(string userID)
        {
            var messages = await _messageRepository.GetMessageByUserID(userID);
            return new SuccessResponse
            {
                Message = "Get Total Message By UserID Successfully",
                Data = messages.Count
            };
        }

        public async Task<SuccessResponse> DeleteMessage(int id)
        {
            await _messageRepository.Delete(id);
            return new SuccessResponse
            {
                Message = "Delete Message Successfully",

            };
        }

        public async Task<SuccessResponse> changeStatus(int id)
        {
            var message = await _messageRepository.GetById(id);
            message.isRead = true;
            await _messageRepository.Update(message);
            return new SuccessResponse
            {
                Message = "Change Status Successfully",
                Data = _mapper.Map<MessageResponse>(message)
            };
        }
    }
}
