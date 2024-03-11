using API.Models;
using API.Repositoriest.GenericRepository;
using Microsoft.EntityFrameworkCore;


namespace API.Repositoriest.image
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(RoomContext context) : base(context)
        {
        }

        public async Task<List<Image>> GetImageByRoomId(int roomId)
        {
            return await _context.Images
                .Where(p => p.roomID == roomId)
                .ToListAsync();
        }

    }

}
