using API.Dtos.Room;
using API.Exceptions;
using API.Models;
using API.Repositoriest.image;
using API.Repositoriest.room;
using API.Repositoriest.user;
using API.Repositoriest.ward;
using API.Response;
using AutoMapper;
using FluentValidation;
using System.Net;

namespace API.Services.room
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IWardRepository _wardRepository;
        private readonly IValidator<RoomAddRequest> _roomAddValidator;
        private readonly IImageRepository _imageRepository;

        public RoomService(IRoomRepository roomRepository, IMapper mapper, IUserRepository userRepository, IWardRepository wardRepository, IValidator<RoomAddRequest> roomAddValidator, IImageRepository imageRepository)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _wardRepository = wardRepository;
            _roomAddValidator = roomAddValidator;
            _imageRepository = imageRepository;
        }

        public async Task<SuccessResponse> GetRooms()
        {
            var rooms = await _roomRepository.GetAllForAdmin();
            // Remove room in rooms that status is false and deleteAt is not null
            rooms.RemoveAll(p => p.status == false && p.deleteAt != null);

            var response = _mapper.Map<List<RoomResponse>>(rooms);
            foreach (var room in response)
            {
                var ward = await _wardRepository.GetWard(room.wardID);
                room.ward = ward.ward_name;
                room.district = ward.district;
                room.districtID = ward.district_id;
                room.provinceID = ward.province_id;
                room.province = ward.province;
                var user = await _userRepository.GetUserById(room.userID);
                room.actorName = user.fullName;
                var images = await _imageRepository.GetImageByRoomId(room.roomID);
                room.images = images.Select(p => p.url).ToList();

            }
            return new SuccessResponse
            {
                Message = "Get rooms successfully",
                Data = response
            };
        }
        public async Task<SuccessResponse> GetRoomsForUser()
        {
            var rooms = await _roomRepository.GetAllForUser();
            // Remove room in rooms that status is false and deleteAt is not null
            rooms.RemoveAll(p => p.status == false && p.deleteAt != null);

            var response = _mapper.Map<List<RoomResponse>>(rooms);
            foreach (var room in response)
            {
                var ward = await _wardRepository.GetWard(room.wardID);
                room.ward = ward.ward_name;
                room.district = ward.district;
                room.province = ward.province;
                room.districtID = ward.district_id;
                room.provinceID = ward.province_id;
                var user = await _userRepository.GetUserById(room.userID);
                room.actorName = user.fullName;
                var images = await _imageRepository.GetImageByRoomId(room.roomID);
                room.images = images.Select(p => p.url).ToList();

            }
            return new SuccessResponse
            {
                Message = "Get rooms successfully",
                Data = response
            };
        }

        public async Task<SuccessResponse> GetRoom(int id)
        {
            var room = await _roomRepository.GetById(id);
            if (room == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room not found");
            }
            var response = _mapper.Map<RoomResponse>(room);
            var ward = await _wardRepository.GetWard(room.wardID);
            response.ward = ward.ward_name;
            response.district = ward.district;
            response.province = ward.province;
            response.districtID = ward.district_id;
            response.provinceID = ward.province_id;
            var user = await _userRepository.GetUserById(room.userID);
            response.actorName = user.fullName;
            var images = await _imageRepository.GetImageByRoomId(room.roomID);
            response.images = images.Select(p => p.url).ToList();
            return new SuccessResponse
            {
                Message = "Get room successfully",
                Data = response
            };
        }

        public async Task<SuccessResponse> CreateRoom(RoomAddRequest request)
        {
            var validationResult = await _roomAddValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(e => e.PropertyName)
                    .Select(g => g.First())
                    .ToDictionary(failure => failure.PropertyName, failure => failure.ErrorMessage)
                    ;
                return new SuccessResponse
                {
                    Message = "Create room failed",
                    Errors = new ErrorResponse
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Data = errors
                    }
                };

            }
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
            var requestAdd = _mapper.Map<RoomAddRequest>(request);
            var validationResult = await _roomAddValidator.ValidateAsync(requestAdd);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(e => e.PropertyName)
                    .Select(g => g.First())
                    .ToDictionary(failure => failure.PropertyName, failure => failure.ErrorMessage)
                    ;
                return new SuccessResponse
                {
                    Message = "Create room failed",
                    Errors = new ErrorResponse
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Data = errors
                    }
                };

            }

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

        public async Task<SuccessResponse> ChangeDelete(int id)
        {
            var room = await _roomRepository.GetById(id);
            if (room == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room not found");
            }
            await _roomRepository.ChangeDelete(id);
            return new SuccessResponse
            {
                Message = "Change status room successfully",
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
