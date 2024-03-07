using API.Dtos.RoomAmenities;
using API.Repositoriest.room_amenities;
using API.Response;
using AutoMapper;
namespace API.Services.room_amenities
{
    public class RoomAmenitiesService
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

    }
}
