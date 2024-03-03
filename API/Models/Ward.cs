using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Ward
    {
        [Key]
        public int wardID { get; set; }
        public string wardName { get; set; }
        public string wardType { get; set; }
        public int districtID { get; set; }

        [ForeignKey("districtID")]
        public District District { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
