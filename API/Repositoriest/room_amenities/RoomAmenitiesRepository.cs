using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.room_amenities
{
    public class RoomAmenitiesRepository : Repository<RoomAmenities>, IRoomAmenitiesRepository
    {
        public RoomAmenitiesRepository(RoomContext context) : base(context)
        {
        }
    }
}
