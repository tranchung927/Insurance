using System.ComponentModel.DataAnnotations;

namespace Server.Models.Users
{
    public class SignInModel
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
