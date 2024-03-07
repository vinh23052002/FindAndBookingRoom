using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.user
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserById(string id);
    }
}
