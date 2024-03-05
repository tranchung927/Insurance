using InsuranceCore.Data;
using InsuranceCore.Models.DTOs.Category;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;
using InsuranceCore.Specifications;

namespace InsuranceCore.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategoryDto>> GetAllCategories();

        public Task<IEnumerable<GetCategoryDto>> GetCategories(FilterSpecification<Category>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Category>? sortSpecification = null);

        public Task<int> CountCategoriesWhere(FilterSpecification<Category>? filterSpecification = null);

        Task<GetCategoryDto> GetCategory(int id);

        Task<GetCategoryDto> AddCategory(AddCategoryDto category);

        Task UpdateCategory(UpdateCategoryDto category);

        Task DeleteCategory(int id);
    }
}
