using API.Models;
using API.Repositoriest.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace API.Repositoriest.message
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(RoomContext context) : base(context)
        {

        }

        public async Task<List<Message>> GetMessageByUserID(string userID)
        {
            return await _context.Messages
                .Include(p => p.Room)
                .Where(p => p.Room.userID.Equals(userID))
                .ToListAsync();

        }
    }

}
