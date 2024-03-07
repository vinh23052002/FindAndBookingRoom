using API.Dtos.Province;

namespace API.Services.province
{
    public interface IProvinceService
    {
        Task<ProvinceResponse> AddProvince(ProvinceRequest provinceRequest);
        Task<List<ProvinceResponse>> GetProvinces();
    }
}