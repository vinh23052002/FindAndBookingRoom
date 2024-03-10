namespace API.Response
{
    public class SuccessResponse
    {
        public string Message { get; set; }
        public Object? Data { get; set; }
        public ErrorResponse Errors { get; set; }
    }


    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public Object? Data { get; set; }
    }
}
