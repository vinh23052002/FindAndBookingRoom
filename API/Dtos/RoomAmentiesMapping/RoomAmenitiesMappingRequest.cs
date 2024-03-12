namespace API.Dtos.RoomAmentiesMapping
{
    public class RoomAmenitiesMappingRequest
    {
        public int roomID { get; set; }
        public int amenitiesID { get; set; }
        public int price { get; set; }
    }

    public class RoomAmenitiesMappingDeleteRequest
    {
        public int roomID { get; set; }
        public int amenitiesID { get; set; }
    }
}
