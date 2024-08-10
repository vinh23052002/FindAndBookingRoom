using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.chat
{
    public interface IChatRepository : IRepository<Chat>
    {
        Task DeleteReview(Chat review);
        Task<Chat> GetReview(int roomID, string userID);
        Task<List<Chat>> GetReviewsByRoomId(int roomId);
        Task<List<Chat>> GetReviewsByRoomID(int roomID);
    }
}