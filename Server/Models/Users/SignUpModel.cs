﻿using System.ComponentModel.DataAnnotations;

namespace Server.Models.Users
{
    public class SignUpModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public int Status { get; set; } = 1;
    }
}
