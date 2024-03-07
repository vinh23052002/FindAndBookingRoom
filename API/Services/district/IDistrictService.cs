using API.Dtos.District;

namespace API.Services.district
{
    public interface IDistrictService
    {
        Task<DistrictResponse> AddDistrict(DistrictRequest districtRequest);
        Task<DistrictResponse> GetDistrict(int id);
        Task<List<DistrictResponse>> GetDistricts();
        Task<List<DistrictResponse>> GetDistrictsByProvinceID(int id);
    }
}