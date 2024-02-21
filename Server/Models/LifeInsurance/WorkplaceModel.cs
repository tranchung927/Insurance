using System.ComponentModel.DataAnnotations;

namespace Server.Models.LifeInsurance
{
    public class WorkplaceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Describe { get; set; }

        public float Factor { get; set; }

        public int Status { get; set; }
    }
}
