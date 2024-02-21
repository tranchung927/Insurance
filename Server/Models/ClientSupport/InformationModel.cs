using Server.Data.ClientSupport;
using Server.Data.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.ClientSupport
{
    public class InformationModel
    {
        public int Id { get; set; }

        public string Problem { get; set; }

        public string Comment { get; set; }

        public int Status { get; set; }

        public string UsersId { get; set; }

        public int InsuranceTypeId { get; set; }

    }
}
