using API.Dtos.Image;
using API.Services.image;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageResponse>>> GetImages()
        {
            var images = await _imageService.GetImages();
            return Ok(images);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImageResponse>> GetImage(int id)
        {
            var image = await _imageService.GetImage(id);
            return Ok(image);
        }

        [HttpPost]
        public async Task<ActionResult<ImageResponse>> AddImage(ImageRequest imageRequest)
        {
            var image = await _imageService.AddImage(imageRequest);
            return Ok(image);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ImageResponse>> UpdateImage(int id, ImageRequest imageRequest)
        {
            var image = await _imageService.UpdateImage(id, imageRequest);
            return Ok(image);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ImageResponse>> DeleteImage(int id)
        {
            var image = await _imageService.DeleteImage(id);
            return Ok(image);
        }
    }
}
