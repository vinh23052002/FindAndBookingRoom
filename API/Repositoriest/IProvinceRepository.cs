using API.Dtos.Province;
using API.Models;

namespace API.Repositoriest
{
    public interface IProvinceRepository
    {
        Task<ProvinceResponse> AddProvince(ProvinceRequest province);
        Task<Province> DeleteProvince(int id);
        Task<Province> GetProvince(int id);
        Task<Province> GetProvinceByID(int id);
        Task<List<ProvinceResponse>> GetProvinces();
        Task<Province> UpdateProvince(int id, Province province);
    }
}