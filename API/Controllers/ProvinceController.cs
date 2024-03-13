using API.Dtos.Province;
using API.Response;
using API.Services.province;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProvinceResponse>>> GetProvinces()
        {
            var respone = await _provinceService.GetProvinces();
            return Ok(new SuccessResponse
            {
                Message = "Get Provinces Successfully",
                Data = respone
            });
        }
        [HttpPost]
        public async Task<ActionResult<ProvinceResponse>> AddProvince([FromBody] ProvinceRequest province)
        {
            var respone = await _provinceService.AddProvince(province);
            return Ok(new SuccessResponse
            {
                Message = "Add Province Successfully",
                Data = respone
            });
        }
    }
}
