using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.room
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(RoomContext context) : base(context)
        {
        }
    }

}
