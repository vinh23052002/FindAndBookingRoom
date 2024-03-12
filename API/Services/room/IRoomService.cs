using API.Dtos.Room;
using API.Response;

namespace API.Services.room
{
    public interface IRoomService
    {
        Task<SuccessResponse> ChangeStatus(int id);
        Task<SuccessResponse> ChangeDelete(int id);
        Task<SuccessResponse> CreateRoom(RoomAddRequest request);
        Task<SuccessResponse> GetRoom(int id);
        Task<SuccessResponse> GetRooms();
        Task<SuccessResponse> UpdateRoom(RoomUpdateRequest request);
        Task<SuccessResponse> GetRoomsForUser();
    }
}