using System;
namespace InsuranceCore.Models.DTOs.HouseCoefficient
{
	public class UpdateHouseCoefficientDto : ADto, IHouseCoefficientDto
	{
        public int HouseTypeId { get; set; }

        public int HouseSizeId { get; set; }

        public float Coefficient { get; set; }
		
        public int Status { get; set; } = 1;
	}
}

