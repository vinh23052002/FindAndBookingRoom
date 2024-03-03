using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class RoomAmenities
    {
        [Key]
        public int amenitiesID { get; set; }
        public string amenitiesName { get; set; }
        public double amenitiesPrice { get; set; }
        public string amenitiesDescription { get; set; }

        public ICollection<RoomAmenitiesMapping> RoomAmenitiesMappings { get; set; }
    }
}
