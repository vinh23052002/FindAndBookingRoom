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

        public async Task<User> Login(string userID, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.userID.Equals(userID) && x.password.Equals(password));
        }

        public async Task ChangeStatus(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user.deleteAt == null)
            {
                user.deleteAt = DateTime.Now;
            }
            else
            {
                user.deleteAt = null;
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.email.Equals(email));
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.phone.Equals(phone));
        }

    }
}
