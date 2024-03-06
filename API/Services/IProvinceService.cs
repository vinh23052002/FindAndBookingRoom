using API.Dtos.Province;

namespace API.Services
{
    public interface IProvinceService
    {
        Task<ProvinceResponse> AddProvince(ProvinceRequest provinceRequest);
        Task<List<ProvinceResponse>> GetProvinces();
    }
}