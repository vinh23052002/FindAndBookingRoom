using API.Models;
using API.Repositoriest.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace API.Repositoriest.room
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(RoomContext context) : base(context)
        {
        }

        public async Task ChangeDelete(int id)
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

        public async Task ChangeStatus(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            room.status = !room.status;
            if (room.status == true)
            {
                room.publicDate = DateTime.Now;
            }
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Room>> GetAllForUser()
        {
            return await _context.Rooms
                .Where(p => p.status == true && p.deleteAt == null)
                .OrderByDescending(p => p.publicDate)
                .OrderByDescending(p => p.status)
                .ToListAsync();
        }

        public async Task<List<Room>> GetAllForAdmin()
        {
            return await _context.Rooms
                .Where(p => p.deleteAt == null)
                .OrderByDescending(p => p.createDate)
                .OrderByDescending(p => p.status)
                .ToListAsync();
        }

        public async Task<List<Room>> GetRoomByUserID(string userID)
        {
            return await _context.Rooms
                .Where(p => p.userID == userID)
                .ToListAsync();
        }
    }

}
