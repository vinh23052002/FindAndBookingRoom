using API.Dtos.Ward;
using API.Exceptions;
using API.Repositoriest;
using System.Net;

namespace API.Services
{
    public class WardService : IWardService
    {
        private readonly IWardRepository _wardRepository;
        private readonly IDistrictRepository _districtRepository;

        public WardService(IWardRepository wardRepository, IDistrictRepository districtRepository)
        {
            _wardRepository = wardRepository;
            _districtRepository = districtRepository;
        }

        public async Task<List<WardResponse>> GetWards()
        {
            return await _wardRepository.GetWards();
        }
        public async Task<WardResponse> GetWard(int id)
        {
            return await _wardRepository.GetWard(id);
        }
        public async Task<WardResponse> AddWard(WardRequest wardRequest)
        {
            var ward = await _wardRepository.GetWard(wardRequest.ward_id);
            if (wardRequest == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Ward is null");
            }
            if (ward != null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Ward is already exist");
            }
            var district = await _districtRepository.GetDistrict(wardRequest.district_id);
            if (district == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "District is not exist");
            }

            return await _wardRepository.AddWard(wardRequest);
        }

        public async Task<List<WardResponse>> GetWardsByDistrictID(int id)
        {
            var district = await _districtRepository.GetDistrict(id);
            if (district == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "District is not exist");
            }
            return await _wardRepository.GetWardsByDistrictID(id);
        }
    }
}
