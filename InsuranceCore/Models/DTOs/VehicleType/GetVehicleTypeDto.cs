using System;
namespace InsuranceCore.Models.DTOs.VehicleType
{
	public class GetVehicleTypeDto : ADto, IVehicleTypeDto
    {
        public string Name { get; set; }
        public int Status { get; set; }
    }
}

