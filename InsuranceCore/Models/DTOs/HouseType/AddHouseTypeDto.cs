using System;
namespace InsuranceCore.Models.DTOs.HouseType
{
	public class AddHouseTypeDto : ADto, IHouseTypeDto
    {
        public string Name { get; set; }
        public int Status { get; set; }
    }
}

