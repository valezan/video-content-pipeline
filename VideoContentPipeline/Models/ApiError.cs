namespace VideoContentPipeline.Models
{
    public class ApiError
    {
        public ApiError(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}