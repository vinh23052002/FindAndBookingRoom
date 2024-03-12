using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.room
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task ChangeDelete(int id);
        Task<List<Room>> GetAllForUser();
        Task<List<Room>> GetAllForAdmin();
        Task ChangeStatus(int id);
    }
}
