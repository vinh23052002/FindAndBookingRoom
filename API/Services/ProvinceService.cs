using API.Dtos.Province;
using API.Exceptions;
using API.Repositoriest;
using System.Net;

namespace API.Services
{
    public class ProvinceService : IProvinceService
    {
        IProvinceRepository _provinceRepository;
        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }
        public async Task<List<ProvinceResponse>> GetProvinces()
        {
            return await _provinceRepository.GetProvinces();
        }

        public async Task<ProvinceResponse> AddProvince(ProvinceRequest provinceRequest)
        {
            var province = await _provinceRepository.GetProvinceByID(provinceRequest.province_id);

            if (provinceRequest == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Province is null");
            }

            if (province != null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Province already exists");
            }

            return await _provinceRepository.AddProvince(provinceRequest);

        }
    }
}
