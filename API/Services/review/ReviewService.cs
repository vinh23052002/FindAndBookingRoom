using API.Dtos.Review;
using API.Exceptions;
using API.Models;
using API.Repositoriest.review;
using API.Repositoriest.room;
using API.Repositoriest.user;
using API.Response;
using AutoMapper;
using System.Net;

namespace API.Services.review
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper, IRoomRepository roomRepository, IUserRepository userRepository)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _roomRepository = roomRepository;
            _userRepository = userRepository;
        }

        public async Task<SuccessResponse> GetReview(ReviewRequest request)
        {
            var review = await _reviewRepository.GetReview(request.roomID, request.userID);
            if (review == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Review not found");
            }
            return new SuccessResponse
            {
                Data = _mapper.Map<ReviewResponse>(review),
                Message = "Review found"
            };
        }

        public async Task<SuccessResponse> GetReviewsByRoomId(int roomId)
        {
            if (await _roomRepository.GetById(roomId) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room not found");
            }
            var reviews = await _reviewRepository.GetReviewsByRoomId(roomId);
            return new SuccessResponse
            {
                Data = _mapper.Map<List<ReviewResponse>>(reviews),
                Message = "Reviews found"
            };
        }

        public async Task<SuccessResponse> AddReview(ReviewRequest request)
        {
            //if (await _roomRepository.GetById(request.roomID) == null)
            //{
            //    throw new MyException((int)HttpStatusCode.NotFound, "Room not found");
            //}
            if (await _userRepository.GetUserById(request.userID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "User not found");
            }
            if (await _reviewRepository.GetReview(request.roomID, request.userID) != null)
            {
                //throw new MyException((int)HttpStatusCode.BadRequest, "Review already exists");
                return new SuccessResponse
                {
                    Data = null,
                    Message = "Review already exists"
                };
            }
            var review = _mapper.Map<Review>(request);
            review.reviewDate = DateTime.Now;
            review.comment = "";
            review.grade = 0;
            var room = await _roomRepository.GetById(request.roomID);
            room.totalView += 1;
            await _reviewRepository.Add(review);
            return new SuccessResponse
            {
                Data = _mapper.Map<ReviewResponse>(review),
                Message = "Review added"
            };
        }

        public async Task<SuccessResponse> UpdateReview(ReviewRequest request)
        {
            if (await _roomRepository.GetById(request.roomID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room not found");
            }
            if (await _userRepository.GetUserById(request.userID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "User not found");
            }
            var review = await _reviewRepository.GetReview(request.roomID, request.userID);
            if (review == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Review not found");
            }
            _mapper.Map(request, review);
            await _reviewRepository.Update(review);
            return new SuccessResponse
            {
                Data = _mapper.Map<ReviewResponse>(review),
                Message = "Review updated"
            };
        }

        public async Task<SuccessResponse> DeleteReview(ReviewDeleteRequest request)
        {
            var review = await _reviewRepository.GetReview(request.roomID, request.userID);
            if (review == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Review not found");
            }
            await _reviewRepository.DeleteReview(review);
            return new SuccessResponse
            {
                Data = _mapper.Map<ReviewResponse>(review),
                Message = "Review deleted"
            };
        }
    }
}
