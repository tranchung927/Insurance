﻿namespace InsuranceCore.Models.DTOs.Account
{
    /// <summary>
    /// UPDATE Dto type of <see cref="Account"/>.
    /// </summary>
    public class UpdateAccountDto : ADto, IAccountDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string UserDescription { get; set; }
    }
}
