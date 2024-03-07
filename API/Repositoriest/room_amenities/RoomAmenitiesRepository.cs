using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.room_amenities
{
    public class RoomAmenitiesRepository : Repository<RoomAmenities>
    {
        public RoomAmenitiesRepository(RoomContext context) : base(context)
        {
        }
    }
}
