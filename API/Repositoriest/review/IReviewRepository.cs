using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.review
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<Review> GetReview(int roomID, string userID);
        Task<List<Review>> GetReviewsByRoomId(int roomId);
        Task DeleteReview(Review review);
    }
}
