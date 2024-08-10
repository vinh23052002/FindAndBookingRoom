using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Chat
{
    public class ChatResponse
    {
        public int chatID { get; set; }
        public int roomID { get; set; }
        public string userID { get; set; }
        public string userName { get; set; }
        [StringLength(500)]
        public string? comment { get; set; }
        [DataType(DataType.Date)]
        public DateTime? reviewDate { get; set; }
    }
}
