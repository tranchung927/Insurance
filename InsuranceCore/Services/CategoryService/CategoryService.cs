﻿using AutoMapper;
using FluentValidation;
using InsuranceCore.Data;
using InsuranceCore.Models.DTOs.Category;
using InsuranceCore.Models.Exceptions;
using InsuranceCore.Repositories.Category;
using InsuranceCore.Repositories.UnitOfWork;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;
using InsuranceCore.Specifications;

namespace InsuranceCore.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<ICategoryDto> _dtoValidator;

        public CategoryService(ICategoryRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<ICategoryDto> dtoValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _dtoValidator = dtoValidator;
        }

        public async Task<IEnumerable<GetCategoryDto>> GetAllCategories()
        {
            return (await _repository.GetAllAsync()).Select(x => _mapper.Map<GetCategoryDto>(x)).ToList();
        }

        public async Task<IEnumerable<GetCategoryDto>> GetCategories(FilterSpecification<Category>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Category>? sortSpecification = null)
        {
            return (await _repository.GetAsync(filterSpecification, pagingSpecification, sortSpecification)).Select(x => _mapper.Map<GetCategoryDto>(x));
        }

        public async Task<int> CountCategoriesWhere(FilterSpecification<Category>? filterSpecification = null)
        {
            return await _repository.CountWhereAsync(filterSpecification);
        }

        public async Task<GetCategoryDto> GetCategory(int id)
        {
            return _mapper.Map<GetCategoryDto>(await _repository.GetAsync(id));
        }

        public async Task CheckCategoryValidity(AddCategoryDto category)
        {
            if (await _repository.NameAlreadyExists(category.Name))
                throw new InvalidRequestException("Name already exists.");
        }

        public async Task CheckCategoryValidity(UpdateCategoryDto category)
        {
            if (await _repository.NameAlreadyExists(category.Name) &&
                (await _repository.GetAsync(category.Id)).Name != category.Name)
                throw new InvalidRequestException("Name already exists.");
        }

        public async Task<GetCategoryDto> AddCategory(AddCategoryDto category)
        {
            await _dtoValidator.ValidateAndThrowAsync(category);
            await CheckCategoryValidity(category);
            var result = await _repository.AddAsync(_mapper.Map<Category>(category));
            _unitOfWork.Save();
            return _mapper.Map<GetCategoryDto>(result);
        }

        private async Task<bool> CategoryAlreadyExistsWithSameProperties(UpdateCategoryDto category)
        {
            var categoryDb = await _repository.GetAsync(category.Id);
            return categoryDb.Name == category.Name;
        }

        public async Task UpdateCategory(UpdateCategoryDto category)
        {
            await _dtoValidator.ValidateAndThrowAsync(category);
            if (await CategoryAlreadyExistsWithSameProperties(category))
                return;
            await CheckCategoryValidity(category);
            var categoryEntity = await _repository.GetAsync(category.Id);
            _mapper.Map(category, categoryEntity);
            _unitOfWork.Save();
        }

        public async Task DeleteCategory(int id)
        {
            await _repository.RemoveAsync(await _repository.GetAsync(id));
            _unitOfWork.Save();
        }
    }
}
