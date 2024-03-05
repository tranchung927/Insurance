using System;
namespace InsuranceCore.Models.DTOs.HouseCoefficient
{
	public interface IHouseCoefficientDto
	{
        public int HouseTypeId { get; set; }

        public int HouseSizeId { get; set; }

        public float Coefficient { get; set; }
		
        public int Status { get; set; }
	}
}

