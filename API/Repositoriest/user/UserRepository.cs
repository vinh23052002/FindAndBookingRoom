using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.user
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RoomContext context) : base(context)
        {
        }
    }
}
