using System;
namespace InsuranceCore.Models.DTOs.VehicleType
{
	public class GetVehicleTypeDto : IVehicleTypeDto
    {
        public string Name { get; set; }
        public int Status { get; set; }
    }
}

