using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Authorization.Attributes;
using Server.Data.Permission;
using Server.Models.Builders.Specifications;
using Server.Models.Builders.Specifications.Category;
using Server.Models.DTOs.Category;
using Server.Models.DTOs.Post;
using Server.Models.Queries;
using Server.Responses;
using Server.Services.CategoryService;
using Server.Services.PostService;

namespace Server.Controllers
{
    /// <summary>
    /// Controller used to expose Category resources of the API.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriesController"/> class.
        /// </summary>
        /// <param name="categoryService"></param>
        /// <param name="postService"></param>
        public CategoriesController(ICategoryService categoryService, IPostService postService)
        {
            _categoryService = categoryService;
            _postService = postService;
        }

        /// <summary>
        /// Get list of categories.
        /// </summary>
        /// <remarks>
        /// Get list of categories. The endpoint uses pagination and sort. Filter(s) can be applied for research.
        /// </remarks>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PageInsuranceResponse<GetCategoryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategoryQueryParameters parameters)
        {
            parameters ??= new GetCategoryQueryParameters();

            var pagingSpecificationBuilder = new PagingSpecificationBuilder(parameters.Page, parameters.PageSize);

            var filterSpecification = new CategoryFilterSpecificationBuilder()
                .WithInName(parameters.InName)
                .WithMinimumPostCount(parameters.MinimumPosts)
                .WithMaximumPostCount(parameters.MaximumPosts)
                .Build();
            var data = await _categoryService.GetCategories(filterSpecification,
                pagingSpecificationBuilder.Build(), new CategorySortSpecificationBuilder(parameters.OrderBy, parameters.SortBy).Build());

            return Ok(new PageInsuranceResponse<GetCategoryDto>(data, pagingSpecificationBuilder.Page, pagingSpecificationBuilder.Limit,
                await _categoryService.CountCategoriesWhere(filterSpecification)));
        }

        /// <summary>
        /// Get a category by giving its Id.
        /// </summary>
        /// <remarks>
        /// Get a category by giving its Id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _categoryService.GetCategory(id));
        }

        /// <summary>
        /// Add a category.
        /// </summary>
        /// <remarks>
        /// Add a category.
        /// </remarks>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [PermissionWithPermissionRangeAllRequired(PermissionAction.CanCreate, PermissionTarget.Category)]
        [ProducesResponseType(typeof(GetCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddCategory(AddCategoryDto user)
        {
            return Ok(await _categoryService.AddCategory(user));
        }

        /// <summary>
        /// Update a category.
        /// </summary>
        /// <remarks>
        /// Update a category.
        /// </remarks>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [PermissionWithPermissionRangeAllRequired(PermissionAction.CanUpdate, PermissionTarget.Category)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto category)
        {
            if (await _categoryService.GetCategory(category.Id) == null)
                return NotFound();
            await _categoryService.UpdateCategory(category);
            return Ok();
        }

        /// <summary>
        /// Delete a category by giving its id.
        /// </summary>
        /// <remarks>
        /// Delete a category by giving its id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [PermissionWithPermissionRangeAllRequired(PermissionAction.CanDelete, PermissionTarget.Category)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (await _categoryService.GetCategory(id) == null)
                return NotFound();
            await _categoryService.DeleteCategory(id);
            return Ok();
        }

        /// <summary>
        /// Get posts from a category by giving category's id.
        /// </summary>
        /// <remarks>
        /// Get posts from a category by giving category's id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}/Posts")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<GetPostDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPostFromCategory(int id)
        {
            return Ok(await _postService.GetPostsFromCategory(id));
        }
    }
}
