using System;
using AutoMapper;
using InsuranceCore.Data;
using InsuranceCore.Models.DTOs.Product;
using InsuranceCore.Repositories.Product;
using InsuranceCore.Repositories.UnitOfWork;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.ProductService
{
	public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetProductDto>> GetAllProducts()
        {
            return (await _repository.GetAllAsync()).Select(x => _mapper.Map<GetProductDto>(x)).ToList();
        }

        public async Task<IEnumerable<GetProductDto>> GetProducts(FilterSpecification<Product>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Product>? sortSpecification = null)
        {
            return (await _repository.GetAsync(filterSpecification, pagingSpecification, sortSpecification)).Select(x => _mapper.Map<GetProductDto>(x));
        }

        public async Task<int> CountProductsWhere(FilterSpecification<Product>? filterSpecification = null)
        {
            return await _repository.CountWhereAsync(filterSpecification);
        }

        public async Task<GetProductDto> GetProduct(int id)
        {
            return _mapper.Map<GetProductDto>(await _repository.GetAsync(id));
        }

        public async Task<GetProductDto> AddProduct(AddProductDto Product)
        {
            var result = await _repository.AddAsync(_mapper.Map<Product>(Product));
            _unitOfWork.Save();
            return _mapper.Map<GetProductDto>(result);
        }

        public async Task UpdateProduct(UpdateProductDto Product)
        {
            var ProductEntity = await _repository.GetAsync(Product.Id);
            _mapper.Map(Product, ProductEntity);
            _unitOfWork.Save();
        }

        public async Task DeleteProduct(int id)
        {
            await _repository.RemoveAsync(await _repository.GetAsync(id));
            _unitOfWork.Save();
        }
    }
}

