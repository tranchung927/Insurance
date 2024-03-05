using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCore.Models.DTOs.HouseSize
{
	public interface IHouseSizeDto
	{
        public string Name { get; set; }
        public int Status { get; set; }
    }
}

