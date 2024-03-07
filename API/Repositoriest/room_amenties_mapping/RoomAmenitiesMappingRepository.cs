using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.room_amenties_mapping
{
    public class RoomAmenitiesMappingRepository : Repository<RoomAmenitiesMapping>, IRoomAmenitiesMappingRepository
    {
        public RoomAmenitiesMappingRepository(RoomContext context) : base(context)
        {
        }
    }
}
