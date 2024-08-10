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
                .OrderByDescending(p => p.totalView)
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

        public async Task<List<Room>> SearchRoomByProvinceID(int provinceID, string txtSearch)
        {
            return await _context.Rooms
                .Include(p => p.Ward)
                .ThenInclude(p => p.District)
                .Where(p => p.name.ToLower().Trim().Contains(txtSearch.ToLower().Trim()) && p.Ward.District.province_id == provinceID)
                .OrderByDescending(p => p.totalView)
                .ToListAsync();
        }

        public async Task<List<Room>> SearchRoomByDistrictID(int districtID, string txtSearch)
        {
            return await _context.Rooms
                .Include(p => p.Ward)
                .Where(p => p.name.ToLower().Trim().Contains(txtSearch.ToLower().Trim()) && p.Ward.district_id == districtID)
                .OrderByDescending(p => p.totalView)
                .ToListAsync();
        }

        public async Task<List<Room>> SearchRoomByWardID(int wardID, string txtSearch)
        {
            return await _context.Rooms
                .Include(p => p.Ward)
                .ThenInclude(p => p.District)
                .Where(p => p.name.ToLower().Trim().Contains(txtSearch.ToLower().Trim()) && p.wardID == wardID)
                .OrderByDescending(p => p.totalView)
                .ToListAsync();
        }

        public async Task<List<Room>> SearchRoomByTxt(string txtSearch)
        {
            return await _context.Rooms
                .Where(p => p.name.ToLower().Trim().Contains(txtSearch.ToLower().Trim()))
                .OrderByDescending(p => p.totalView)
                .ToListAsync();
        }
    }

}
