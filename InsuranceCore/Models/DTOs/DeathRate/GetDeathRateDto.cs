using System;
namespace InsuranceCore.Models.DTOs.DeathRate
{
	public class GetDeathRateDto : ADto, IDeathRateDto
	{
        public int Age { get; set; }
        public float Male { get; set; }
        public float Female { get; set; }
        public int Status { get; set; }
    }
}

