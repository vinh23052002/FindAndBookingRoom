using API.Dtos.District;
using API.Exceptions;
using API.Repositoriest.district;
using API.Repositoriest.province;
using System.Net;

namespace API.Services.district
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IProvinceRepository _provinceRepository;

        public DistrictService(IDistrictRepository districtRepository, IProvinceRepository provinceRepository)
        {
            _districtRepository = districtRepository;
            _provinceRepository = provinceRepository;
        }

        public async Task<List<DistrictResponse>> GetDistricts()
        {
            return await _districtRepository.GetDistricts();
        }
        public async Task<DistrictResponse> GetDistrict(int id)
        {
            return await _districtRepository.GetDistrict(id);
        }

        public async Task<DistrictResponse> AddDistrict(DistrictRequest districtRequest)
        {
            var district = await _districtRepository.GetDistrict(districtRequest.district_id);
            if (districtRequest == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "District is null");
            }
            if (district != null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "District is already exist");
            }
            var province = await _provinceRepository.GetProvinceByID(districtRequest.province_id);
            if (province == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Province is not exist");
            }

            return await _districtRepository.AddDistrict(districtRequest);
        }

        public async Task<List<DistrictResponse>> GetDistrictsByProvinceID(int id)
        {
            return await _districtRepository.GetDistrictsByProvinceID(id);
        }
    }
}
