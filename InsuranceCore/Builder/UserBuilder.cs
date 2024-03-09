using InsuranceCore.Data;

namespace InsuranceCore.Builder
{
    public class UserBuilder
    {
        private string _email;
        private string _username;
        private string _firstName;
        private string _lastName;
        private string _userDescription;

        public UserBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public UserBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public UserBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public UserBuilder WithDescription(string userDescription)
        {
            _userDescription = userDescription;
            return this;
        }

        public UserBuilder WithUsername(string username)
        {
            _username = username;
            return this;
        }

        public User Build()
        {
            return new User
            {
                FirstName = _firstName,
                LastName = _lastName,
                Email = _email,
                UserName = _username,
                UserDescription = _userDescription,
                Address = ""
            };
        }
    }
}
