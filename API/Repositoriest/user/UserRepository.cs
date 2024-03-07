using API.Models;
using API.Repositoriest.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace API.Repositoriest.user
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RoomContext context) : base(context)
        {
        }

        public async Task<User> GetUserById(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.userID.Equals(id));
        }
    }
}
