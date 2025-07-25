namespace AdventureWorksAPI.Middlewares.ErrorHandling
{
    public class ValidationExceptions : Exception
    {
        public ValidationExceptions(string message) : base(message) { }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message) { }
    }

    public class RateLimitExceededException : Exception
    {
        public RateLimitExceededException(string message):base(message){}
    }
}