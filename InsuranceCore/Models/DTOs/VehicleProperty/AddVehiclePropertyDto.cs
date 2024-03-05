using System;
namespace InsuranceCore.Models.DTOs.VehicleProperty
{
	public class AddVehiclePropertyDto : IVehiclePropertyDto
    {

        public string Property { get; set; }


        public int Value { get; set; }


        public int Status { get; set; }

        public int VehicleTypeId { get; set; }

    }
}

