using API.Dtos.Image;
using API.Exceptions;
using API.Models;
using API.Repositoriest.image;
using API.Repositoriest.room;
using API.Response;
using AutoMapper;
using System.Net;

namespace API.Services.image
{
    public class ImageService : IImageService
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;
        private readonly IRoomRepository _roomRepository;

        public ImageService(IMapper mapper, IImageRepository imageRepository, IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
            _roomRepository = roomRepository;
        }

        public async Task<SuccessResponse> GetImages()
        {
            var images = await _imageRepository.GetAll();
            var imagesDto = _mapper.Map<List<ImageResponse>>(images);
            return new SuccessResponse
            {
                Message = "Images retrieved successfully",
                Data = imagesDto
            };
        }

        public async Task<SuccessResponse> GetImage(int id)
        {
            var image = await _imageRepository.GetById(id);
            if (image == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Image not found");
            }
            var imageDto = _mapper.Map<ImageResponse>(image);
            return new SuccessResponse
            {
                Message = "Image retrieved successfully",
                Data = imageDto
            };
        }

        public async Task<SuccessResponse> GetImageByRoomID(int id)
        {
            var images = await _imageRepository.GetImageByRoomId(id);
            if (images == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Images not found");
            }
            var imagesDto = _mapper.Map<List<ImageResponse>>(images);
            return new SuccessResponse
            {
                Message = "Images retrieved successfully",
                Data = imagesDto
            };
        }

        public async Task<SuccessResponse> AddImage(ImageRequest imageRequest)
        {
            if (imageRequest == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Image request is null");
            }

            if (await _roomRepository.GetById(imageRequest.roomID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room not found");
            }

            var image = _mapper.Map<Image>(imageRequest);
            var addedImage = await _imageRepository.Add(image);
            var imageDto = _mapper.Map<ImageResponse>(addedImage);
            return new SuccessResponse
            {
                Message = "Image added successfully",
                Data = imageDto
            };
        }

        public async Task<SuccessResponse> UpdateImage(int id, ImageRequest imageRequest)
        {
            if (imageRequest == null)
            {
                throw new MyException((int)HttpStatusCode.BadRequest, "Image request is null");
            }

            if (await _roomRepository.GetById(imageRequest.roomID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Room not found");
            }

            var image = await _imageRepository.GetById(id);
            if (image == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Image not found");
            }
            _mapper.Map(imageRequest, image);
            var updatedImage = await _imageRepository.Update(image);
            var imageDto = _mapper.Map<ImageResponse>(updatedImage);
            return new SuccessResponse
            {
                Message = "Image updated successfully",
                Data = imageDto
            };
        }

        public async Task<SuccessResponse> DeleteImage(int id)
        {

            var image = await _imageRepository.Delete(id);
            if (image == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Image not found");
            }
            var imageDto = _mapper.Map<ImageResponse>(image);
            return new SuccessResponse
            {
                Message = "Image deleted successfully",
                Data = imageDto
            };
        }

    }
}
