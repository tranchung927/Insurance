using Server.Data.ClientSupport;
using Server.Data.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.ClientSupport
{
    public class TicketModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Phone must be numeric")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone must be 10 digits")]
        public string Phone { get; set; }


        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string Problem { get; set; }

        public string? Comment { get; set; }

        public int Status { get; set; }

        public string? UsersId { get; set; }

        public int InsuranceTypeId { get; set; }

        // Constructor
       

    }
}
