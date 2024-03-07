using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.room_amenties_mapping
{
    public class RoomAmenitiesMappingRepository : Repository<RoomAmenitiesMapping>
    {
        public RoomAmenitiesMappingRepository(RoomContext context) : base(context)
        {
        }
    }
}
