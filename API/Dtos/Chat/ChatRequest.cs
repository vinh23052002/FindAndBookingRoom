using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Chat
{
    public class ChatRequest
    {
        public int roomID { get; set; }
        public string userID { get; set; }

        [StringLength(500)]
        public string? comment { get; set; }
    }
}
