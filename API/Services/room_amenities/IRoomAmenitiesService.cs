using API.Dtos.RoomAmenities;
using API.Response;

namespace API.Services.room_amenities
{
    public interface IRoomAmenitiesService
    {
        Task<SuccessResponse> CreateRoomAmenities(RoomAmenitiesRequest roomAmenitiesRequest);
        Task<SuccessResponse> DeleteRoomAmenities(int id);
        Task<SuccessResponse> GetRoomAmenities();
        Task<SuccessResponse> GetRoomAmenitiesById(int id);
        Task<SuccessResponse> UpdateRoomAmenities(int id, RoomAmenitiesRequest roomAmenitiesRequest);
    }
}