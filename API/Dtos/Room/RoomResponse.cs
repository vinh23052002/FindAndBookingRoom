using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Room
{
    public class RoomResponse
    {
        public int roomID { get; set; }
        public int wardID { get; set; }
        public int districtID { get; set; }
        public int provinceID { get; set; }
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
        public string ward { get; set; }
        public string district { get; set; }
        public string province { get; set; }
        public List<String> images { get; set; }
        public string actorName { get; set; }
    }
}
