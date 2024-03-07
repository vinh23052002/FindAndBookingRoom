using API.Dtos.District;

namespace API.Repositoriest.district
{
    public interface IDistrictRepository
    {
        Task<DistrictResponse> AddDistrict(DistrictRequest districtRequest);
        Task<DistrictResponse> GetDistrict(int id);
        Task<List<DistrictResponse>> GetDistricts();
        Task<List<DistrictResponse>> GetDistrictsByProvinceID(int id);
    }
}