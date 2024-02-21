using System.ComponentModel.DataAnnotations;

namespace Server.Models.HomeInsurance
{
    public class HomeTypeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Status { get; set; } = 1;
    }
}
