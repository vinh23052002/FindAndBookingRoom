using API.Dtos.RoomAmentiesMapping;
using API.Models;
using API.Repositoriest.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace API.Repositoriest.room_amenties_mapping
{
    public class RoomAmenitiesMappingRepository : Repository<RoomAmenitiesMapping>, IRoomAmenitiesMappingRepository
    {
        public RoomAmenitiesMappingRepository(RoomContext context) : base(context)
        {
        }

        public async Task<List<RoomAmenitiesMapping>> GetRoomAmenitiesMappingByRoomId(int roomId)
        {
            return await _context.RoomAmenitiesMappings.Where(x => x.roomID == roomId).ToListAsync();
        }

        public async Task<RoomAmenitiesMapping> GetRoomAmenitiesMappingByAmenitiesId(int amenitiesId)
        {
            return await _context.RoomAmenitiesMappings.FirstOrDefaultAsync(x => x.amenitiesID == amenitiesId);
        }

        public async Task Remove(RoomAmenitiesMappingRequest roomAmenitiesMappingRequest)
        {
            var roomAmenitiesMapping = await _context.RoomAmenitiesMappings.FirstOrDefaultAsync(x => x.roomID == roomAmenitiesMappingRequest.roomID && x.amenitiesID == roomAmenitiesMappingRequest.amenitiesID);
            if (roomAmenitiesMapping != null)
            {
                _context.RoomAmenitiesMappings.Remove(roomAmenitiesMapping);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<RoomAmenitiesMapping> Get(int roomID, int amenitiesID)
        {
            return await _context.RoomAmenitiesMappings.FirstOrDefaultAsync(x => x.roomID == roomID && x.amenitiesID == amenitiesID);
        }
    }
}
