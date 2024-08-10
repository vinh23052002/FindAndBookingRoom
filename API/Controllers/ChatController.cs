using API.Dtos.Chat;
using API.Services.chat;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }
        [HttpGet("By-Room/{id}")]
        public async Task<IActionResult> GetMessageByRoomID(int id)
        {
            var response = await _chatService.GetMessageByRoomID(id);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateMessage(ChatRequest request)
        {
            var response = await _chatService.CreateMessage(request);
            return Ok(response);
        }
    }
}
