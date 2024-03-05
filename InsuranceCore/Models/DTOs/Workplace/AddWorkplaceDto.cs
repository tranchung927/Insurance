using System;
namespace InsuranceCore.Models.DTOs.Workplace
{
	public class AddWorkplaceDto: IWorkplaceDto
    {

        public string Name { get; set; }


        public string Describe { get; set; }


        public float Factor { get; set; }


        public int Status { get; set; }
    }
}

