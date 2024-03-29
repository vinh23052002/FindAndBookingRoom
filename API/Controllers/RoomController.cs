﻿using API.Dtos.Room;
using API.Services.room;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> GetRooms()
        {
            var response = await _roomService.GetRoomsForAdmin();
            return Ok(response);
        }
        [HttpGet("for-user")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRoomsForUser()
        {
            var response = await _roomService.GetRoomsForUser();
            return Ok(response);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRoom(int id)
        {
            var response = await _roomService.GetRoom(id);
            return Ok(response);
        }

        [HttpGet("by-user/{userID}")]
        public async Task<IActionResult> GetRoomsByUserID(string userID)
        {
            var response = await _roomService.GetRoomsByUserID(userID);
            return Ok(response);
        }

        [HttpGet("search-by-province")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchByProvince(int provinceID, string? txtSearch = "")
        {
            txtSearch = txtSearch ?? "";
            var response = await _roomService.SearchRoomByProvinceID(provinceID, txtSearch);
            return Ok(response);
        }

        [HttpGet("search-by-district")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchByDistrict(int districtID, string? txtSearch = "")
        {
            txtSearch = txtSearch ?? "";
            var response = await _roomService.SearchRoomByDistrict(districtID, txtSearch);
            return Ok(response);
        }

        [HttpGet("search-by-ward")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchByWard(int wardID, string? txtSearch = "")
        {
            txtSearch = txtSearch ?? "";
            var response = await _roomService.SearchRoomByWardID(wardID, txtSearch);
            return Ok(response);
        }

        [HttpGet("search-by-txt")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchByTxt(string? txtSearch = "")
        {
            txtSearch = txtSearch ?? "";
            var response = await _roomService.SearchRoomByTxt(txtSearch);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomAddRequest request)
        {
            var response = await _roomService.CreateRoom(request);
            if (response.Errors != null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("delete/{id}")]
        public async Task<IActionResult> ChangeDelete(int id)
        {
            var response = await _roomService.ChangeDelete(id);
            return Ok(response);
        }

        [HttpPut("change-status/{id}")]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            var response = await _roomService.ChangeStatus(id);
            return Ok(response);
        }

        [HttpPut("update-room")]
        public async Task<IActionResult> UpdateRoom(RoomUpdateRequest request)
        {
            var response = await _roomService.UpdateRoom(request);
            if (response.Errors != null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
