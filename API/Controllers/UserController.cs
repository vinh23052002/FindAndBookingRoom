using API.Dtos.User;
using API.Services.user;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var response = await _userService.Login(request);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRequest request)
        {
            var response = await _userService.Register(request);
            return Ok(response);
        }

        [HttpPost("update-profile")]
        public async Task<IActionResult> UpdateProfile(UserUpdateProfileRequest request)
        {
            var response = await _userService.UpdateProfile(request);
            return Ok(response);
        }

        [HttpPost("change-status")]
        public async Task<IActionResult> ChangeStatus(string id)
        {
            var response = await _userService.ChangeStatus(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();
            return Ok(response);
        }

        [HttpPost("update-user")]
        public async Task<IActionResult> UpdateUser(UserRequest request)
        {
            var response = await _userService.UpdateUser(request);
            return Ok(response);
        }

    }
}
