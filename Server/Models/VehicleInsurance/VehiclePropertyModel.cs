using Server.Data.VehicleInsurance;

namespace Server.Models.VehicleInsurance
{
    public class VehiclePropertyModel
    {
        public int Id { get; set; }

        public string Property { get; set; }

        public int Value { get; set; }

        public int Status { get; set; } = 1;

        public int VehicleTypeId { get; set; }

        public VehicleTypeEntity VehicleType { get; set; }

    }
}
