using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Message
    {
        [Key]
        public int messageID { get; set; }
        public int roomID { get; set; }
        public string userName { get; set; }
        [RegularExpression(@"^\d{9,10}$", ErrorMessage = "Phone number must be 9 or 10 digits.")]
        public string phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string content { get; set; }
        public DateTime sendDate { get; set; }
        public bool isRead { get; set; }

        [ForeignKey("roomID")]
        public Room Room { get; set; }
    }
}
