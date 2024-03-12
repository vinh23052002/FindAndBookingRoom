using API.Dtos.RoomAmenities;

namespace API.Dtos.RoomAmentiesMapping
{
    public class RoomAmenitiesMappingResponse
    {
        public int roomID { get; set; }
        public int amenitiesID { get; set; }
        public int price { get; set; }

        public RoomAmenitiesResponse RoomAmenities { get; set; }

    }
}
