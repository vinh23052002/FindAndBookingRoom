using API.Dtos.RoomAmentiesMapping;
using API.Exceptions;
using API.Models;
using API.Repositoriest.room;
using API.Repositoriest.room_amenities;
using API.Repositoriest.room_amenties_mapping;
using API.Response;
using AutoMapper;
using System.Net;


namespace API.Services.room_amenities_mapping
{
    public class RoomAmenitiesMappingService : IRoomAmenitiesMappingService
    {
        private readonly IRoomAmenitiesMappingRepository _roomAmenitiesMappingRepository;
        private readonly IMapper _mapper;
        private readonly IRoomAmenitiesRepository _roomAmenitiesRepository;
        private readonly IRoomRepository _roomRepository;

        public RoomAmenitiesMappingService(IRoomAmenitiesMappingRepository roomAmenitiesMappingRepository, IMapper mapper, IRoomAmenitiesRepository roomAmenitiesRepository, IRoomRepository roomRepository)
        {
            _roomAmenitiesMappingRepository = roomAmenitiesMappingRepository;
            _mapper = mapper;
            _roomAmenitiesRepository = roomAmenitiesRepository;
            _roomRepository = roomRepository;
        }

        public async Task<SuccessResponse> GetRoomAmenitiesMapping()
        {
            var roomAmenitiesMapping = await _roomAmenitiesMappingRepository.GetAll();
            var roomAmenitiesMappingDto = _mapper.Map<List<RoomAmenitiesMappingResponse>>(roomAmenitiesMapping);
            return new SuccessResponse
            {
                Message = "Room amenities mapping retrieved successfully",
                Data = roomAmenitiesMappingDto
            };
        }

        public async Task<SuccessResponse> GetRoomAmenitiesMappingByRoomId(int roomID)
        {
            if (await _roomRepository.GetById(roomID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room not found");
            }
            var roomAmenitiesMapping = await _roomAmenitiesMappingRepository.GetRoomAmenitiesMappingByRoomId(roomID);
            var roomAmenitiesMappingDto = _mapper.Map<List<RoomAmenitiesMappingResponse>>(roomAmenitiesMapping);
            return new SuccessResponse
            {
                Message = "Room amenities mapping retrieved successfully",
                Data = roomAmenitiesMappingDto
            };
        }

        public async Task<SuccessResponse> CreateRoomAmenitiesMapping(RoomAmenitiesMappingRequest roomAmenitiesMappingRequest)
        {
            if (await _roomRepository.GetById(roomAmenitiesMappingRequest.roomID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room not found");
            }
            if (await _roomAmenitiesRepository.GetById(roomAmenitiesMappingRequest.amenitiesID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room amenities not found");
            }

            if (await _roomAmenitiesMappingRepository.Get(roomAmenitiesMappingRequest.roomID, roomAmenitiesMappingRequest.amenitiesID) != null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Room amenities  already exists");
            }

            if (roomAmenitiesMappingRequest == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Room amenities mapping request is empty");
            }
            var roomAmenitiesMapping = _mapper.Map<RoomAmenitiesMapping>(roomAmenitiesMappingRequest);
            await _roomAmenitiesMappingRepository.Add(roomAmenitiesMapping);
            return new SuccessResponse
            {
                Message = "Room amenities mapping created successfully",
                Data = _mapper.Map<RoomAmenitiesMappingResponse>(roomAmenitiesMapping)
            };
        }

        public async Task<SuccessResponse> UpdateRoomAmenitiesMapping(int roomID, RoomAmenitiesMappingRequest roomAmenitiesMappingRequest)
        {
            if (roomAmenitiesMappingRequest == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Room amenities mapping request is empty");
            }
            var roomAmenitiesMapping = await _roomAmenitiesMappingRepository.Get(roomID, roomAmenitiesMappingRequest.amenitiesID);
            if (roomAmenitiesMapping == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room amenities mapping not found");
            }
            if (await _roomAmenitiesRepository.GetById(roomAmenitiesMappingRequest.amenitiesID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room amenities not found");
            }
            if (await _roomRepository.GetById(roomAmenitiesMappingRequest.roomID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room not found");
            }
            _mapper.Map(roomAmenitiesMappingRequest, roomAmenitiesMapping);
            await _roomAmenitiesMappingRepository.Update(roomAmenitiesMapping);
            return new SuccessResponse
            {
                Message = "Room amenities mapping updated successfully",
                Data = roomAmenitiesMapping
            };
        }

        public async Task<SuccessResponse> DeleteRoomAmenitiesMapping(RoomAmenitiesMappingDeleteRequest request)
        {
            var roomAmenitiesMapping = await _roomAmenitiesMappingRepository.GetRoomAmenitiesMappingByRoomId(request.roomID);
            if (roomAmenitiesMapping == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room amenities mapping not found");
            }
            await _roomAmenitiesMappingRepository.Remove(request);
            return new SuccessResponse
            {
                Message = "Room amenities mapping deleted successfully",
                Data = roomAmenitiesMapping
            };
        }
    }

}
