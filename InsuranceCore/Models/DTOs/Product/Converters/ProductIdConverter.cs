using System;
using AutoMapper;
using InsuranceCore.Repositories.Product;

namespace InsuranceCore.Models.DTOs.Product.Converters
{
	public class ProductIdConverter : ITypeConverter<int, Data.Product>
    {
        private readonly IProductRepository _repository;

        public ProductIdConverter(IProductRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Data.Product Convert(int source, Data.Product destination, ResolutionContext context)
        {
            return _repository.Get(source);
        }
    }
}

