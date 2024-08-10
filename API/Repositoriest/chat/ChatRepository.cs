using API.Models;
using API.Repositoriest.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace API.Repositoriest.chat
{
    public class ChatRepository : Repository<Chat>, IChatRepository
    {
        public ChatRepository(RoomContext context) : base(context)
        {
        }

        public async Task<List<Chat>> GetReviewsByRoomId(int roomId)
        {
            return await _context.Chats.Where(x => x.roomID == roomId).ToListAsync();
        }

        public async Task<Chat> GetReview(int roomID, string userID)
        {
            return await _context.Chats.FirstOrDefaultAsync(x => x.roomID == roomID && x.userID.Equals(userID));
        }

        public async Task DeleteReview(Chat review)
        {
            _context.Chats.Remove(review);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Chat>> GetReviewsByRoomID(int roomID)
        {
            return await _context.Chats
                .Include(p => p.User)
                .Where(x => x.roomID == roomID)
                .OrderByDescending(x => x.reviewDate)
                .ToListAsync();
        }
    }
}
