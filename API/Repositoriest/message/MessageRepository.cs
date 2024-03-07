using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.message
{
    public class MessageRepository : Repository<Message>
    {
        public MessageRepository(RoomContext context) : base(context)
        {

        }
    }

}
