namespace Server.Models.Mail
{
    public class EmailIdentity
    {
        public string Email { get; }

        public string Name { get; }

        public EmailIdentity(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
