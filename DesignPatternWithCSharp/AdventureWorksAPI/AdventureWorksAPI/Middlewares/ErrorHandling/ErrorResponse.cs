namespace AdventureWorksAPI.Middlewares.ErrorHandling
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public string Details { get; set; }
    }
}