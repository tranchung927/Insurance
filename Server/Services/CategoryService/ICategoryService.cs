using Server.Data;
using Server.Models.DTOs.Category;
using Server.Specifications.FilterSpecifications;
using Server.Specifications.SortSpecification;
using Server.Specifications;

namespace Server.Services.CategoryService
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
