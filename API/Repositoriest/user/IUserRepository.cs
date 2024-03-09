using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.user
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserById(string id);
        Task<User> Login(string userID, string password);
        Task ChangeStatus(string id);
        Task<User> GetUserByPhone(string phone);
        Task<User> GetUserByEmail(string email);
    }
}
