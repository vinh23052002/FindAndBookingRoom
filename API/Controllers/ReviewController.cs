using API.Dtos.Review;
using API.Services.review;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{roomID}")]
        public async Task<IActionResult> GetReviewsByRoomId(int roomID)
        {
            var response = await _reviewService.GetReviewsByRoomId(roomID);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewRequest request)
        {
            var response = await _reviewService.AddReview(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReview(ReviewDeleteRequest request)
        {
            var response = await _reviewService.DeleteReview(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(ReviewRequest request)
        {
            var response = await _reviewService.UpdateReview(request);
            return Ok(response);
        }

    }
}
