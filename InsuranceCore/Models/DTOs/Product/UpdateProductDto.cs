using System;
namespace InsuranceCore.Models.DTOs.Product
{
	public class UpdateProductDto: ADto, IProductDto
    {
        public string Name { get; set; }
        public string Alias { get; set; }
    }
}

