using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.review
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(RoomContext context) : base(context)
        {
        }
    }
}
