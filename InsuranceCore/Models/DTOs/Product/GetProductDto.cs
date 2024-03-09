using System;
namespace InsuranceCore.Models.DTOs.Product
{
	public class GetProductDto : ADto, IProductDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

