namespace API.Dtos.District
{
    public class DistrictRequest
    {
        public int district_id { get; set; }
        public string district_name { get; set; }
        public string district_type { get; set; }
        public string? lat { get; set; }
        public string? lng { get; set; }

        public int province_id { get; set; }
    }
}
