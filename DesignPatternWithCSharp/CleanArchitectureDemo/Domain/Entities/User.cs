namespace Domain.Entities
{
    public class User
    {
        public Guid Id {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}

        public User(string email, string password)
        {
            Id = Guid.NewGuid();
            Password = password;
            Email = email;
        }

        public bool IsValid()
        {
            return Email.Contains("@") && Password.Length >= 6;
        }
    }
}