namespace Application.DTOs
{
    public class RegisterUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}