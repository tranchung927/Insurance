using System;
namespace InsuranceCore.Models.DTOs.VehicleType
{
	public class AddVehicleTypeDto : ADto, IVehicleTypeDto
    {
        public string Name { get; set; }
        public int Status { get; set; }
    }
}

