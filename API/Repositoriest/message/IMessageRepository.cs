using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.message
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<List<Message>> GetMessageByUserID(string userID);
    }
}
