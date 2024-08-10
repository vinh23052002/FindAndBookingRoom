using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Chat
    {
        [Key]
        public int chatID { get; set; }
        public int roomID { get; set; }
        public string userID { get; set; }

        [StringLength(500)]
        public string? comment { get; set; }
        [DataType(DataType.Date)]
        public DateTime? reviewDate { get; set; }

        [ForeignKey("roomID")]
        public Room Room { get; set; }
        [ForeignKey("userID")]
        public User User { get; set; }
    }
}
