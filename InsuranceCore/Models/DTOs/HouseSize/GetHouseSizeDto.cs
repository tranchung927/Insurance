using System;
namespace InsuranceCore.Models.DTOs.HouseSize
{
	public class GetHouseSizeDto : IHouseSizeDto
    {
        public string Name { get; set; }
        public int Status { get; set; }
    }
}

