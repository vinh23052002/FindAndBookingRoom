using API.Dtos.User;
using API.Response;

namespace API.Services.user
{
    public interface IUserService
    {
        Task<SuccessResponse> ChangeStatus(string id);
        Task<SuccessResponse> GetUserById(string id);
        Task<SuccessResponse> Login(UserLoginRequest request);
        Task<SuccessResponse> Register(UserRequest request);
        Task<SuccessResponse> UpdateProfile(UserUpdateProfileRequest request);
        Task<SuccessResponse> UpdateUser(UserRequest request);
        Task<SuccessResponse> GetUsers();
    }
}