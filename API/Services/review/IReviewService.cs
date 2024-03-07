using API.Dtos.Review;
using API.Response;

namespace API.Services.review
{
    public interface IReviewService
    {
        Task<SuccessResponse> AddReview(ReviewRequest request);
        Task<SuccessResponse> DeleteReview(ReviewDeleteRequest request);
        Task<SuccessResponse> GetReview(ReviewRequest request);
        Task<SuccessResponse> GetReviewsByRoomId(int roomId);
        Task<SuccessResponse> UpdateReview(ReviewRequest request);
    }
}