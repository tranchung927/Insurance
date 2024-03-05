using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCore.Models.DTOs.Workplace
{
	public interface IWorkplaceDto
	{
       
        public string Name { get; set; }

       
        public string Describe { get; set; }

      
        public float Factor { get; set; }

     
        public int Status { get; set; }
    }
}

