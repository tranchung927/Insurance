using System;
using InsuranceCore.Data;
using InsuranceCore.Models.DTOs.Product;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.ProductService
{
	public interface IProductService
	{
        Task<IEnumerable<GetProductDto>> GetAllProducts();

        public Task<IEnumerable<GetProductDto>> GetProducts(FilterSpecification<Product>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Product>? sortSpecification = null);

        public Task<int> CountProductsWhere(FilterSpecification<Product>? filterSpecification = null);

        Task<GetProductDto> GetProduct(int id);

        Task<GetProductDto> AddProduct(AddProductDto product);

        Task UpdateProduct(UpdateProductDto product);

        Task DeleteProduct(int id);
    }
}

