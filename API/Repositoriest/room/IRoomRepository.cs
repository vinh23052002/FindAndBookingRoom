using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.room
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task ChangeDelete(int id);
        Task<List<Room>> GetAllForUser();
        Task<List<Room>> GetAllForAdmin();
        Task ChangeStatus(int id);
        Task<List<Room>> GetRoomByUserID(string userID);
        Task<List<Room>> SearchRoomByProvinceID(int provinceID, string txtSearch);
        Task<List<Room>> SearchRoomByDistrictID(int districtID, string txtSearch);
        Task<List<Room>> SearchRoomByWardID(int wardID, string txtSearch);
        Task<List<Room>> SearchRoomByTxt(string txtSearch);

    }

}
