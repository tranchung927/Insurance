using System;
namespace InsuranceCore.Models.DTOs.HouseType
{
	public class GetHouseTypeDto : IHouseTypeDto
    {
        public string Name { get; set; }
        public int Status { get; set; }
    }
}

