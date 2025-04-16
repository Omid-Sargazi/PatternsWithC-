using System.Globalization;

namespace Patterns.RegisterSchool

{
    public class UserBuilder
    {
        private User _user;
        public UserBuilder()
        {
            _user = new User();
        }
        public UserBuilder WithName(string name)
        {
            _user.SetName(name);
            return this;
        }
        public UserBuilder WithEmail(string email)
        {
            _user.SetEmail(email);
            return this;
        }
        public UserBuilder WithPassword(string password)
        {
            _user.SetPassword(password);
            return this;
        }
        public UserBuilder WithRole(string role)
        {
            _user.SetRole(role);
            return this;
        }
        public UserBuilder WithPhoneNumber(string phoneNumber)
        {
            _user.SetPhoneNumber(phoneNumber);
            return this;
        }
        public UserBuilder WithProfilePicture(string profilePicture)
        {
            _user.SetProfilePicture(profilePicture);
            return this;
        }
        public User Build()
        {
            return _user;
        }
    }
}