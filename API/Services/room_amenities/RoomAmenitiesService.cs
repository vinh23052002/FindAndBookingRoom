using API.Dtos.RoomAmenities;
using API.Exceptions;
using API.Models;
using API.Repositoriest.room_amenities;
using API.Response;
using AutoMapper;
using System.Net;
namespace API.Services.room_amenities
{
    public class RoomAmenitiesService : IRoomAmenitiesService
    {
        private readonly IMapper _mapper;
        private readonly IRoomAmenitiesRepository _roomAmenitiesRepository;

        public RoomAmenitiesService(IMapper mapper, IRoomAmenitiesRepository roomAmenitiesRepository)
        {
            _mapper = mapper;
            _roomAmenitiesRepository = roomAmenitiesRepository;
        }

        public async Task<SuccessResponse> GetRoomAmenities()
        {
            var roomAmenities = await _roomAmenitiesRepository.GetAll();
            var roomAmenitiesDto = _mapper.Map<List<RoomAmenitiesResponse>>(roomAmenities);
            return new SuccessResponse
            {
                Message = "Room amenities retrieved successfully",
                Data = roomAmenitiesDto
            };
        }

        public async Task<SuccessResponse> GetRoomAmenitiesById(int id)
        {
            var roomAmenities = await _roomAmenitiesRepository.GetById(id);
            var roomAmenitiesDto = _mapper.Map<RoomAmenitiesResponse>(roomAmenities);
            return new SuccessResponse
            {
                Message = "Room amenities retrieved successfully",
                Data = roomAmenitiesDto
            };
        }

        public async Task<SuccessResponse> CreateRoomAmenities(RoomAmenitiesRequest roomAmenitiesRequest)
        {
            if (roomAmenitiesRequest == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Room amenities request is empty");
            }
            var roomAmenities = _mapper.Map<RoomAmenities>(roomAmenitiesRequest);
            await _roomAmenitiesRepository.Add(roomAmenities);
            return new SuccessResponse
            {
                Message = "Room amenities created successfully",
                Data = roomAmenities
            };
        }

        public async Task<SuccessResponse> UpdateRoomAmenities(int id, RoomAmenitiesRequest roomAmenitiesRequest)
        {
            if (roomAmenitiesRequest == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Room amenities request is empty");
            }
            var roomAmenities = await _roomAmenitiesRepository.GetById(id);
            if (roomAmenities == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room amenities not found");
            }
            _mapper.Map(roomAmenitiesRequest, roomAmenities);
            await _roomAmenitiesRepository.Update(roomAmenities);
            return new SuccessResponse
            {
                Message = "Room amenities updated successfully",
                Data = roomAmenities
            };
        }

        public async Task<SuccessResponse> DeleteRoomAmenities(int id)
        {
            var roomAmenities = await _roomAmenitiesRepository.GetById(id);
            if (roomAmenities == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room amenities not found");
            }
            await _roomAmenitiesRepository.Delete(id);
            return new SuccessResponse
            {
                Message = "Room amenities deleted successfully",
                Data = roomAmenities
            };
        }

    }
}
