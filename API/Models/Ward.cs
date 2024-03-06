using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Ward
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ward_id { get; set; }
        public string ward_name { get; set; }
        public string ward_type { get; set; }
        public int district_id { get; set; }
        public string? lat { get; set; }
        public string? lng { get; set; }

        [ForeignKey("district_id")]
        public District District { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
