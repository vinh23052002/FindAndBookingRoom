using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Image
    {
        [Key]
        public int imageID { get; set; }
        public string url { get; set; }
        public int roomID { get; set; }
        public int order { get; set; }
        [ForeignKey("roomID")]
        public Room Room { get; set; }
    }
}
