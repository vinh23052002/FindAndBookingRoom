using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.message
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(RoomContext context) : base(context)
        {

        }
    }

}
