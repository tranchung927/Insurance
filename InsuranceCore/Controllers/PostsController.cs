using InsuranceCore.Authorization.Permissions;
using InsuranceCore.Data.Permission;
using InsuranceCore.Models.Builders.Specifications.Post;
using InsuranceCore.Models.Builders.Specifications;
using InsuranceCore.Models.DTOs.Post;
using InsuranceCore.Models.Queries;
using InsuranceCore.Services.PostService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InsuranceCore.Responses;

namespace InsuranceCore.Controllers
{
    /// <summary>
    /// Controller used to expose Post resources of the API.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IAuthorizationService _authorizationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostsController"/> class.
        /// </summary>
        /// <param name="postService"></param>
        /// <param name="commentService"></param>
        /// <param name="likeService"></param>
        /// <param name="authorizationService"></param>
        public PostsController(IPostService postService,
            IAuthorizationService authorizationService)
        {
            _postService = postService;
            _authorizationService = authorizationService;
        }

        /// <summary>
        /// Get list of posts.
        /// </summary>
        /// <remarks>
        /// Get list of posts. The endpoint uses pagination and sort. Filter(s) can be applied for research.
        /// </remarks>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PageInsuranceResponse<GetPostDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPosts([FromQuery] GetPostQueryParameters parameters)
        {
            parameters ??= new GetPostQueryParameters();

            var pagingSpecificationBuilder = new PagingSpecificationBuilder(parameters.Page, parameters.PageSize);
            var filterSpecification = new PostFilterSpecificationBuilder()
                .WithInContent(parameters.InContent)
                .WithInName(parameters.InName)
                .WithInContent(parameters.InContent)
                .WithToPublishedAt(parameters.ToPublicationDate)
                .WithFromPublishedAt(parameters.FromPublicationDate)
                .WithTags(parameters.Tagged)
                .Build();
            var data = await _postService.GetPosts(filterSpecification,
                pagingSpecificationBuilder.Build(), new SortPostFilter(parameters.OrderBy, parameters.SortBy).GetSorting());

            return Ok(new PageInsuranceResponse<GetPostDto>(data, pagingSpecificationBuilder.Page, pagingSpecificationBuilder.Limit,
                await _postService.CountPostsWhere(filterSpecification)));
        }

        /// <summary>
        /// Get a post by giving its Id.
        /// </summary>
        /// <remarks>
        /// Get a post by giving its Id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetPostDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _postService.GetPost(id));
        }

        /// <summary>
        /// Add a post.
        /// </summary>
        /// <remarks>
        /// Add a post.
        /// </remarks>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(GetPostDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddPost(AddPostDto post)
        {
            var authorized = await _authorizationService.AuthorizeAsync(User, post, new PermissionRequirement(PermissionAction.CanCreate, PermissionTarget.Post));
            if (!authorized.Succeeded)
                return Forbid();

            return Ok(await _postService.AddPost(post));
        }

        /// <summary>
        /// Update a post.
        /// </summary>
        /// <remarks>
        /// Update a post.
        /// </remarks>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdatePost(UpdatePostDto post)
        {
            var authorized = await _authorizationService.AuthorizeAsync(User, post, new PermissionRequirement(PermissionAction.CanUpdate, PermissionTarget.Post));
            if (!authorized.Succeeded)
                return Forbid();

            await _postService.UpdatePost(post);
            return Ok();
        }

        /// <summary>
        /// Delete a post by giving its id.
        /// </summary>
        /// <remarks>
        /// Delete a post by giving its id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePost(int id)
        {
            var postDto = await _postService.GetPost(id);
            var authorized = await _authorizationService.AuthorizeAsync(User, postDto, new PermissionRequirement(PermissionAction.CanDelete, PermissionTarget.Post));
            if (!authorized.Succeeded)
                return Forbid();

            await _postService.DeletePost(id);
            return Ok();
        }
    }
}
