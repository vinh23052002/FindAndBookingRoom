using API.Dtos.Ward;
using API.Response;
using API.Services.ward;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : ControllerBase
    {
        private readonly IWardService _wardService;
        private readonly IMapper _mapper;

        public WardController(IWardService wardService, IMapper mapper)
        {
            _wardService = wardService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WardResponse>>> GetWards()
        {
            var wards = await _wardService.GetWards();
            return Ok(new SuccessResponse
            {
                Message = "Get wards successfully",
                Data = _mapper.Map<List<WardResponse>>(wards)
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WardResponse>> GetWard(int id)
        {
            var ward = await _wardService.GetWard(id);
            return Ok(new SuccessResponse
            {
                Message = "Get ward successfully",
                Data = _mapper.Map<WardResponse>(ward)
            });

        }


        [HttpPost]
        public async Task<ActionResult<WardResponse>> AddWard(WardRequest wardRequest)
        {
            var ward = await _wardService.AddWard(wardRequest);
            return Ok(new SuccessResponse
            {
                Message = "Add ward successfully",
                Data = ward
            });
        }

        [HttpGet("district/{id}")]
        public async Task<ActionResult<IEnumerable<WardResponse>>> GetWardsByDistrictID(int id)
        {
            var wards = await _wardService.GetWardsByDistrictID(id);
            return Ok(new SuccessResponse
            {
                Message = "Get wards by districtID successfully",
                Data = _mapper.Map<List<WardResponse>>(wards)
            });
        }

    }
}
