using System;
namespace InsuranceCore.Models.DTOs.VehicleType
{
	public class UpdateVehicleTypeDto: IVehicleTypeDto
    {
        public string Name { get; set; }
        public int Status { get; set; }
    }
}

