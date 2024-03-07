using API.Dtos.RoomAmenities;
using API.Services.room_amenities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAmenitiesController : ControllerBase
    {
        private readonly IRoomAmenitiesService _roomAmenitiesService;

        public RoomAmenitiesController(IRoomAmenitiesService roomAmenitiesService)
        {
            _roomAmenitiesService = roomAmenitiesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoomAmenities()
        {
            var response = await _roomAmenitiesService.GetRoomAmenities();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomAmenitiesById(int id)
        {
            var response = await _roomAmenitiesService.GetRoomAmenitiesById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoomAmenities(RoomAmenitiesRequest roomAmenitiesRequest)
        {
            var response = await _roomAmenitiesService.CreateRoomAmenities(roomAmenitiesRequest);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoomAmenities(int id, RoomAmenitiesRequest roomAmenitiesRequest)
        {
            var response = await _roomAmenitiesService.UpdateRoomAmenities(id, roomAmenitiesRequest);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomAmenities(int id)
        {
            var response = await _roomAmenitiesService.DeleteRoomAmenities(id);
            return Ok(response);
        }
    }
}
