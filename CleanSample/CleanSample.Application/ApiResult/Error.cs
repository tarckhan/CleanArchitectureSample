namespace CleanSample.Application.ApiResult
{
    public class Error
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public int HttpStatusCode { get; set; }
    }
}
