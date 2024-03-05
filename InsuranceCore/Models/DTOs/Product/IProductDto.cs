using System;
namespace InsuranceCore.Models.DTOs.Product
{
    /// <summary>
    /// Interface of <see cref="Product"/> Dto containing all the common properties of Product Dto Type (GET, ADD, UPDATE).
    /// </summary>
    public interface IProductDto
    {
        public string Name { get; set; }

        public string? Alias { get; set; }
    }
}

