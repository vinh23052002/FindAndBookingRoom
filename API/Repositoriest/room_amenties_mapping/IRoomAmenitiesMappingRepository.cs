using API.Dtos.RoomAmentiesMapping;
using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.room_amenties_mapping
{
    public interface IRoomAmenitiesMappingRepository : IRepository<RoomAmenitiesMapping>
    {
        Task<RoomAmenitiesMapping> GetRoomAmenitiesMappingByAmenitiesId(int amenitiesId);
        Task<List<RoomAmenitiesMapping>> GetRoomAmenitiesMappingByRoomId(int roomId);
        Task Remove(RoomAmenitiesMappingDeleteRequest roomAmenitiesMappingRequest);
        Task<RoomAmenitiesMapping> Get(int roomID, int amenitiesID);
    }
}
