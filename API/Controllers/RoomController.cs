using API.Dtos.Room;
using API.Services.room;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var response = await _roomService.GetRooms();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var response = await _roomService.GetRoom(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomAddRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var response = await _roomService.CreateRoom(request);
            return Ok(response);
        }

        [HttpPut("change-status/{id}")]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            var response = await _roomService.ChangeStatus(id);
            return Ok(response);
        }

    }
}
