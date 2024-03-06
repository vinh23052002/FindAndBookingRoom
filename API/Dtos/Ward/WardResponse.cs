namespace API.Dtos.Ward
{
    public class WardResponse
    {
        public int ward_id { get; set; }
        public string ward_name { get; set; }
        public string ward_type { get; set; }
        public int district_id { get; set; }
        public string? lat { get; set; }
        public string? lng { get; set; }
    }
}
