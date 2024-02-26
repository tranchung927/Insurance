﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using InsuranceCore.Authorization.Permissions;
using InsuranceCore.Models.DTOs.Permission;
using InsuranceCore.Services.RoleService;
using InsuranceCore.Services.UserService;

namespace InsuranceCore.Authorization.PermissionHandlers.Attributes
{
    public class PermissionWithRangeAuthorizationHandler : AuthorizationHandler<PermissionWithRangeRequirement>
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        /// <inheritdoc />
        public PermissionWithRangeAuthorizationHandler(IUserService userService, IRoleService roleService, IMapper mapper)
        {
            _userService = userService;
            _roleService = roleService;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public override async Task HandleAsync(AuthorizationHandlerContext context)
        {
            foreach (var req in context.Requirements.OfType<PermissionWithRangeRequirement>())
            {
                await HandleRequirementAsync(context, req);
            }
        }

        /// <inheritdoc />
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionWithRangeRequirement withRangeRequirement)
        {
            var userId = context.User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            if (string.IsNullOrEmpty(userId))
                return;

            var account = await _userService.GetAccount(int.Parse(userId));
            if (account.Roles.Any())
            {
                var requirementAction = _mapper.Map<PermissionActionDto>(withRangeRequirement.Permission);
                var requirementTarget = _mapper.Map<PermissionTargetDto>(withRangeRequirement.PermissionTarget);
                var requirementRange = _mapper.Map<PermissionRangeDto>(withRangeRequirement.PermissionRange);

                foreach (var role in account.Roles)
                {
                    var permissions = await _roleService.GetPermissionsAsync(role);

                    if (permissions != null && permissions.Any(permission =>
                            requirementAction.Id == permission.PermissionAction.Id &&
                            requirementTarget.Id == permission.PermissionTarget.Id &&
                            requirementRange.Id == permission.PermissionRange.Id))
                    {
                        context.Succeed(withRangeRequirement);
                        return;
                    }
                }
            }
        }
    }
}
