using InsuranceCore.Authorization.Attributes;
using InsuranceCore.Authorization.Permissions;
using InsuranceCore.Data.Permission;
using InsuranceCore.Models.Builders.Specifications.User;
using InsuranceCore.Models.Builders.Specifications;
using InsuranceCore.Models.DTOs.Post;
using InsuranceCore.Models.DTOs.Role;
using InsuranceCore.Models.DTOs.User;
using InsuranceCore.Models.Queries;
using InsuranceCore.Services.PostService;
using InsuranceCore.Services.RoleService;
using InsuranceCore.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InsuranceCore.Responses;

namespace InsuranceCore.Controllers
{
    /// <summary>
    /// Controller used to expose User resources of the API.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IPostService _postService;
        private readonly IAuthorizationService _authorizationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="likeService"></param>
        /// <param name="postService"></param>
        /// <param name="commentService"></param>
        /// <param name="roleService"></param>
        /// <param name="authorizationService"></param>
        public UsersController(IUserService userService, IPostService postService,
             IRoleService roleService, IAuthorizationService authorizationService)
        {
            _userService = userService;
            _postService = postService;
            _roleService = roleService;
            _authorizationService = authorizationService;
        }

        /// <summary>
        /// Get list of users.
        /// </summary>
        /// <remarks>
        /// Get list of users. The endpoint uses pagination and sort. Filter(s) can be applied for research.
        /// </remarks>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PageInsuranceResponse<GetUserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers([FromQuery] GetUserQueryParameters parameters)
        {
            parameters ??= new GetUserQueryParameters();

            var pagingSpecificationBuilder = new PagingSpecificationBuilder(parameters.Page, parameters.PageSize);
            var filterSpecification = new UserFilterSpecificationBuilder()
                .WithInUserName(parameters.InUserName)
                .WithFromLastLogin(parameters.FromLastLoginDate)
                .WithToLastLogin(parameters.ToLastLoginDate)
                .WithFromRegister(parameters.FromRegistrationDate)
                .WithToRegister(parameters.ToRegistrationDate)
                .Build();
            var data = await _userService.GetUsers(filterSpecification,
                pagingSpecificationBuilder.Build(), new UserSortSpecificationBuilder(parameters.OrderBy, parameters.SortBy).Build());

            return Ok(new PageInsuranceResponse<GetUserDto>(data, pagingSpecificationBuilder.Page, pagingSpecificationBuilder.Limit,
                await _userService.CountUsersWhere(filterSpecification)));
        }

        /// <summary>
        /// Get a user by giving its Id.
        /// </summary>
        /// <remarks>
        /// Get a user by giving its Id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _userService.GetUser(id));
        }

        /// <summary>
        /// Add a role to a user.
        /// </summary>
        /// <remarks>
        /// Add a role to a user.
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost("{id:int}/Role/{roleId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddRoleToUser(int id, int roleId)
        {
            if (await _userService.GetUser(id) == null)
                return NotFound("Doesn't found the user.");
            if (await _roleService.GetRole(roleId) == null)
                return NotFound("Doesn't found the role.");

            var roleEntity = await _roleService.GetRoleEntity(roleId);
            var roleAuthorized = await _authorizationService.AuthorizeAsync(User, roleEntity, new PermissionRequirement(PermissionAction.CanUpdate, PermissionTarget.Role));
            if (!roleAuthorized.Succeeded)
                return Forbid();

            var userEntity = await _userService.GetUserEntity(id);
            var userAuthorized = await _authorizationService.AuthorizeAsync(User, userEntity, new PermissionRequirement(PermissionAction.CanUpdate, PermissionTarget.Account));
            if (!userAuthorized.Succeeded)
                return Forbid();

            await _userService.AddUserRole(new UserRoleDto() { UserId = id, RoleId = roleId });
            return Ok();
        }

        /// <summary>
        /// Remove a role to a user.
        /// </summary>
        /// <remarks>
        /// Remove a role to a user.
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}/Role/{roleId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> RemoveRoleToUser(int id, int roleId)
        {
            if (await _userService.GetUser(id) == null)
                return NotFound("Doesn't found the user.");
            if (await _roleService.GetRole(roleId) == null)
                return NotFound("Doesn't found the role.");

            var roleEntity = await _roleService.GetRoleEntity(roleId);
            var roleAuthorized = await _authorizationService.AuthorizeAsync(User, roleEntity, new PermissionRequirement(PermissionAction.CanUpdate, PermissionTarget.Role));
            if (!roleAuthorized.Succeeded)
                return Forbid();

            var userEntity = await _userService.GetUserEntity(id);
            var userAuthorized = await _authorizationService.AuthorizeAsync(User, userEntity, new PermissionRequirement(PermissionAction.CanUpdate, PermissionTarget.Account));
            if (!userAuthorized.Succeeded)
                return Forbid();

            await _userService.RemoveUserRole(new UserRoleDto { UserId = id, RoleId = roleId });
            return Ok();
        }

        /// <summary>
        /// Define default role(s) assigned to new users.
        /// </summary>
        /// <remarks>
        /// Define default role(s) assigned to new users.
        /// </remarks>
        /// <param name="defaultRoles"></param>
        /// <returns></returns>
        [HttpPost("Roles/Default")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DefineDefaultRolesToNewUsers(DefaultRolesDto defaultRoles)
        {
            // todo : possible improvement : do a AuthorizeAsync without resource parameter needed (only check if have right on all resource type specified)
            // Or something like that, so no more nedeed to give a not useful item (here user)
            var userId = int.Parse(User.Claims
                .First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);

            var user = await _userService.GetUserEntity(userId);
            // end

            var roleAuthorized = await _authorizationService.AuthorizeAsync(User, user, new PermissionRequirement(PermissionAction.CanUpdate, PermissionTarget.Role));
            if (!roleAuthorized.Succeeded)
                return Forbid();

            var userAuthorized = await _authorizationService.AuthorizeAsync(User, user, new PermissionRequirement(PermissionAction.CanUpdate, PermissionTarget.Account));
            if (!userAuthorized.Succeeded)
                return Forbid();

            await _userService.SetDefaultRolesAssignedToNewUsers(defaultRoles.Roles);
            return Ok();
        }

        /// <summary>
        /// Get current default role(s) assigned to new users.
        /// </summary>
        /// <remarks>
        /// Get current default role(s) assigned to new users.
        /// </remarks>
        /// <returns></returns>
        [HttpGet("Roles/Default")]
        [PermissionWithPermissionRangeAllRequired(PermissionAction.CanRead, PermissionTarget.Role)]
        [ProducesResponseType(typeof(IEnumerable<GetRoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDefaultRolesToNewUsers()
        {
            return Ok(await _userService.GetDefaultRolesAssignedToNewUsers());
        }


        /// <summary>
        /// Get posts written by a user by giving user's id.
        /// </summary>
        /// <remarks>
        /// Get posts written by a user by giving user's id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}/Posts/")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<GetPostDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPostsFromUser(int id)
        {
            return Ok(await _postService.GetPostsFromUser(id));
        }
    }
}
