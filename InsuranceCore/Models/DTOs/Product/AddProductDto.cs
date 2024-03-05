using System;
using InsuranceCore.Models.DTOs.Ticket;

namespace InsuranceCore.Models.DTOs.Product
{
	public class AddProductDto : ADto, IProductDto
    {
        public string Name { get; set; }
        public string Alias { get; set; }
    }
}

