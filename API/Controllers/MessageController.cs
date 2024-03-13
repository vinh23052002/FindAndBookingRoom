using API.Dtos.Message;
using API.Services.message;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessage(int id)
        {
            var response = await _messageService.GetMessage(id);
            return Ok(response);
        }

        [HttpGet("by-user/{userID}")]
        public async Task<IActionResult> GetMessageByUserID(string userID)
        {
            var response = await _messageService.GetMessageByUserID(userID);
            return Ok(response);
        }
        [HttpGet("total/{userID}")]
        public async Task<IActionResult> GetTotalMessageByUserID(string userID)
        {
            var response = await _messageService.GetTotalByUserID(userID);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(MessageRequest request)
        {
            var response = await _messageService.CreateMessage(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var response = await _messageService.DeleteMessage(id);
            return Ok(response);
        }
    }
}
