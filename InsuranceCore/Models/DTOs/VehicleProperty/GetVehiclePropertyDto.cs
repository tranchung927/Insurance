using System;
namespace InsuranceCore.Models.DTOs.VehicleProperty
{
	public class GetVehiclePropertyDto : ADto, IVehiclePropertyDto
    {

        public string Property { get; set; }


        public int Value { get; set; }


        public int Status { get; set; }

        public int VehicleTypeId { get; set; }

    }
}

