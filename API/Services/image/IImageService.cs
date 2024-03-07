using API.Dtos.Image;
using API.Response;

namespace API.Services.image
{
    public interface IImageService
    {
        Task<SuccessResponse> AddImage(ImageRequest imageRequest);
        Task<SuccessResponse> GetImage(int id);
        Task<SuccessResponse> GetImages();
        Task<SuccessResponse> UpdateImage(int id, ImageRequest imageRequest);
        Task<SuccessResponse> DeleteImage(int id);
    }
}