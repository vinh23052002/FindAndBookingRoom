using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.room
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(RoomContext context) : base(context)
        {
        }

        public async Task ChangeStatus(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room.deleteAt == null)
            {
                room.deleteAt = DateTime.Now;
            }
            else
            {
                room.deleteAt = null;
            }
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
    }

}
