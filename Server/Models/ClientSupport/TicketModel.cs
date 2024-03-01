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

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Problem { get; set; }

        public string? Comment { get; set; }

        public int Status { get; set; }

        public string? UsersId { get; set; }

        public int InsuranceTypeId { get; set; }

    }
}
