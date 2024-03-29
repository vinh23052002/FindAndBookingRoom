﻿using API.Dtos.User;
using API.Services.user;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var response = await _userService.GetUserById(id);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var response = await _userService.Login(request);
            //Response.Cookies.Append("token", response.Data.ToString(), new CookieOptions
            //{
            //    HttpOnly = true,
            //    Expires = DateTime.UtcNow.AddDays(7),
            //});
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRequest request)
        {
            var response = await _userService.Register(request);
            if (response.Errors != null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile(UserUpdateProfileRequest request)
        {
            var response = await _userService.UpdateProfile(request);
            if (response.Errors != null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("change-status")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> ChangeStatus(string id)
        {
            var response = await _userService.ChangeStatus(id);
            return Ok(response);
        }



        [HttpPut("update-user")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> UpdateUser(UserRequest request)
        {
            var response = await _userService.UpdateUser(request);
            if (response.Errors != null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
