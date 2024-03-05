using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCore.Models.DTOs.DeathRate
{
 
    public interface IDeathRateDto
    {
        public int Age { get; set; }
        public float Male { get; set; }
        public float Female { get; set; }
        public int Status { get; set; }
    }
}

