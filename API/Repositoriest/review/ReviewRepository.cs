using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.review
{
    public class ReviewRepository : Repository<Review>
    {
        public ReviewRepository(RoomContext context) : base(context)
        {
        }
    }
}
