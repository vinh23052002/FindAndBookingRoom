using API.Dtos.Chat;
using API.Response;

namespace API.Services.chat
{
    public interface IChatService
    {
        Task<SuccessResponse> CreateMessage(ChatRequest request);
        Task<SuccessResponse> DeleteMessage(int id);
        Task<SuccessResponse> GetMessage(int id);
        Task<SuccessResponse> GetMessageByRoomID(int roomID);
    }
}