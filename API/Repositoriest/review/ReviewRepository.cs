using API.Models;
using API.Repositoriest.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace API.Repositoriest.review
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(RoomContext context) : base(context)
        {
        }

        public async Task<List<Review>> GetReviewsByRoomId(int roomId)
        {
            return await _context.Reviews.Where(x => x.roomID == roomId).ToListAsync();
        }

        public async Task<Review> GetReview(int roomID, string userID)
        {
            return await _context.Reviews.FirstOrDefaultAsync(x => x.roomID == roomID && x.userID.Equals(userID));
        }

        public async Task DeleteReview(Review review)
        {
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}
