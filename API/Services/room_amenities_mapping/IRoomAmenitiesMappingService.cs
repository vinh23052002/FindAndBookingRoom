using API.Dtos.RoomAmentiesMapping;
using API.Response;

namespace API.Services.room_amenities_mapping
{
    public interface IRoomAmenitiesMappingService
    {
        Task<SuccessResponse> CreateRoomAmenitiesMapping(RoomAmenitiesMappingRequest roomAmenitiesMappingRequest);
        Task<SuccessResponse> DeleteRoomAmenitiesMapping(RoomAmenitiesMappingRequest request);
        Task<SuccessResponse> GetRoomAmenitiesMapping();
        Task<SuccessResponse> GetRoomAmenitiesMappingByRoomId(int roomID);
        Task<SuccessResponse> UpdateRoomAmenitiesMapping(int roomID, RoomAmenitiesMappingRequest roomAmenitiesMappingRequest);
    }
}