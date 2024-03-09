using API.Dtos.Room;
using API.Exceptions;
using API.Models;
using API.Repositoriest.room;
using API.Repositoriest.user;
using API.Repositoriest.ward;
using API.Response;
using AutoMapper;
using System.Net;

namespace API.Services.room
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IWardRepository _wardRepository;

        public RoomService(IRoomRepository roomRepository, IMapper mapper, IUserRepository userRepository, IWardRepository wardRepository)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _wardRepository = wardRepository;
        }

        public async Task<SuccessResponse> GetRooms()
        {
            var rooms = await _roomRepository.GetAll();
            return new SuccessResponse
            {
                Message = "Get rooms successfully",
                Data = _mapper.Map<List<RoomResponse>>(rooms)
            };
        }

        public async Task<SuccessResponse> GetRoom(int id)
        {
            var room = await _roomRepository.GetById(id);
            return new SuccessResponse
            {
                Message = "Get room successfully",
                Data = _mapper.Map<RoomResponse>(room)
            };
        }

        public async Task<SuccessResponse> CreateRoom(RoomAddRequest request)
        {
            if (request == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Request is null");
            }
            if (await _userRepository.GetUserById(request.userID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "User not found");
            }
            if (await _wardRepository.GetWard(request.wardID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Ward not found");
            }

            var room = _mapper.Map<Room>(request);
            room.createDate = DateTime.Now;
            room.status = false;
            await _roomRepository.Add(room);
            return new SuccessResponse
            {
                Message = "Create room successfully",
                Data = _mapper.Map<RoomResponse>(room)
            };
        }

        public async Task<SuccessResponse> UpdateRoom(RoomUpdateRequest request)
        {
            var room = await _roomRepository.GetById(request.roomID);
            if (room == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room not found");
            }
            if (await _wardRepository.GetWard(request.wardID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Ward not found");
            }
            _mapper.Map(request, room);
            await _roomRepository.Update(room);
            return new SuccessResponse
            {
                Message = "Update room successfully",
                Data = _mapper.Map<RoomResponse>(room)
            };
        }

        public async Task<SuccessResponse> ChangeStatus(int id)
        {
            var room = await _roomRepository.GetById(id);
            if (room == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room not found");
            }
            await _roomRepository.ChangeStatus(id);
            return new SuccessResponse
            {
                Message = "Change status room successfully",
                Data = _mapper.Map<RoomResponse>(room)
            };
        }
    }
}
