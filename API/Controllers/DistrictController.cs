using API.Dtos.District;
using API.Response;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;
        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }
        [HttpGet]
        public async Task<ActionResult<List<DistrictResponse>>> GetDistricts()
        {
            var respone = await _districtService.GetDistricts();
            return Ok(new SuccessResponse
            {
                Message = "Get Districts Successfully",
                Data = respone
            });
        }
        [HttpPost]
        public async Task<ActionResult<DistrictResponse>> AddDistrict([FromBody] DistrictRequest district)
        {
            var respone = await _districtService.AddDistrict(district);
            return Ok(new SuccessResponse
            {
                Message = "Add District Successfully",
                Data = respone
            });
        }

        [HttpGet("{provinceID}")]
        public async Task<ActionResult<List<DistrictResponse>>> GetDistrictsByProvinceID(int provinceID)
        {
            var respone = await _districtService.GetDistrictsByProvinceID(provinceID);
            return Ok(new SuccessResponse
            {
                Message = "Get Districts By ProvinceID Successfully",
                Data = respone
            });
        }
    }
}
