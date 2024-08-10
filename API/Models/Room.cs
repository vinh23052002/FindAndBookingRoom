using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Room
    {
        [Key]
        public int roomID { get; set; }
        public int wardID { get; set; }
        public string userID { get; set; }
        [StringLength(100)]
        public string name { get; set; }
        public double price { get; set; }
        public double area { get; set; }
        [DataType(DataType.Date)]
        public DateTime createDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? publicDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? deleteAt { get; set; }
        [StringLength(1000)]
        public string description { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public Boolean status { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int totalView { get; set; }

        public ICollection<Image> Images { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<RoomAmenitiesMapping> RoomAmenitiesMappings { get; set; }
        public ICollection<Chat> Chats { get; set; }


        [ForeignKey("wardID")]
        public Ward Ward { get; set; }
        [ForeignKey("userID")]
        public User User { get; set; }

    }
}
