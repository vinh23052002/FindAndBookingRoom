using API.Dtos.RoomAmentiesMapping;
using API.Services.room_amenities_mapping;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAmenitiesMappingController : ControllerBase
    {
        private readonly IRoomAmenitiesMappingService _roomAmenitiesMappingService;

        public RoomAmenitiesMappingController(IRoomAmenitiesMappingService roomAmenitiesMappingService)
        {
            _roomAmenitiesMappingService = roomAmenitiesMappingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoomAmenitiesMapping()
        {
            var response = await _roomAmenitiesMappingService.GetRoomAmenitiesMapping();
            return Ok(response);
        }

        [HttpGet("{roomID}")]
        public async Task<IActionResult> GetRoomAmenitiesMappingByRoomId(int roomID)
        {
            var response = await _roomAmenitiesMappingService.GetRoomAmenitiesMappingByRoomId(roomID);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoomAmenitiesMapping(RoomAmenitiesMappingRequest roomAmenitiesMappingRequest)
        {
            var response = await _roomAmenitiesMappingService.CreateRoomAmenitiesMapping(roomAmenitiesMappingRequest);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRoomAmenitiesMapping(RoomAmenitiesMappingRequest roomAmenitiesMappingRequest)
        {
            var response = await _roomAmenitiesMappingService.DeleteRoomAmenitiesMapping(roomAmenitiesMappingRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoomAmenitiesMapping(int roomID, RoomAmenitiesMappingRequest roomAmenitiesMappingRequest)
        {
            var response = await _roomAmenitiesMappingService.UpdateRoomAmenitiesMapping(roomID, roomAmenitiesMappingRequest);
            return Ok(response);
        }

    }
}
