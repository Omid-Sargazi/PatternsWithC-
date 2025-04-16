namespace Patterns.RegisterSchool
{
    public class User
    {
         public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public string PhoneNumber { get; private set; }
        public string ProfilePicture { get; private set; }

        internal User(){}
        internal void SetName(string name)=>Name = name;
        internal void SetEmail(string email)=>Email = email;
        internal void SetPassword(string password)=>Password = password;
        internal void SetRole(string role)=>Role = role;
        internal void SetPhoneNumber(string phoneNumber)=>PhoneNumber = phoneNumber;
        internal void SetProfilePicture(string profilePicture)=>ProfilePicture = profilePicture;
    }
}