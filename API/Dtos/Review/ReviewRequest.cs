namespace API.Dtos.Review
{
    public class ReviewRequest
    {
        public int roomID { get; set; }
        public string userID { get; set; }
        //[Range(1, 5)]
        //public float grade { get; set; }
        //[StringLength(500)]
        //public string comment { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime reviewDate { get; set; }
    }

    public class ReviewDeleteRequest
    {
        public int roomID { get; set; }
        public string userID { get; set; }
    }
}
