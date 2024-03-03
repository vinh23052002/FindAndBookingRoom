using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class RoomAmenitiesMapping
    {
        public int roomID { get; set; }
        public int amenitiesID { get; set; }

        [ForeignKey("roomID")]
        public Room Room { get; set; }
        [ForeignKey("amenitiesID")]
        public RoomAmenities RoomAmenities { get; set; }
    }
}
