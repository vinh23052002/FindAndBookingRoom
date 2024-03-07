﻿using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.image
{
    public interface IImageRepository : IRepository<Image>
    {
        Task<Image> GetImageByRoomId(int roomId);
    }
}