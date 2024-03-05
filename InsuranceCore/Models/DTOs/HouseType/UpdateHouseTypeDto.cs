using System;
namespace InsuranceCore.Models.DTOs.HouseType
{
	public class UpdateHouseTypeDto : ADto, IHouseTypeDto
    {
        public string Name { get; set; }
        public int Status { get; set; }
    }
}

