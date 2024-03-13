using API.Dtos.Message;
using API.Response;

namespace API.Services.message
{
    public interface IMessageService
    {
        Task<SuccessResponse> CreateMessage(MessageRequest request);
        Task<SuccessResponse> DeleteMessage(int id);
        Task<SuccessResponse> GetMessage(int id);
        Task<SuccessResponse> GetMessageByUserID(string userID);
        Task<SuccessResponse> GetTotalByUserID(string userID);
    }
}