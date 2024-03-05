using System;
namespace InsuranceCore.Models.DTOs.VehicleProperty
{
	public class UpdateVehiclePropertyDto: ADto, IVehiclePropertyDto
    {

        public string Property { get; set; }


        public int Value { get; set; }


        public int Status { get; set; }

        public int VehicleTypeId { get; set; }

    }
}

