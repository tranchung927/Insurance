﻿using Microsoft.AspNetCore.Identity;
using Server.Data;
using Server.Data.Permission;
using System.Security.Claims;
using System.Text.Json;

namespace Server.Builder
{
    public class RoleBuilder
    {
        private string _name;
        private readonly List<Permission> _permissions;
        private readonly RoleManager<Role> _roleManager;

        public RoleBuilder(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
            _permissions = new List<Permission>();
        }

        public RoleBuilder WithCanReadAllOnAllResourcesExceptAccount()
        {
            WithCanReadAll(PermissionTarget.Category);
            WithCanReadAll(PermissionTarget.News);
            WithCanReadAll(PermissionTarget.Role);
            WithCanReadAll(PermissionTarget.User);
            WithCanReadAll(PermissionTarget.Permission);
            return this;
        }

        public RoleBuilder WithCanUpdateAllOnAllResources()
        {
            WithCanUpdateAll(PermissionTarget.Category);
            WithCanUpdateAll(PermissionTarget.News);
            WithCanUpdateAll(PermissionTarget.Permission);
            WithCanUpdateAll(PermissionTarget.Account);
            return this;
        }

        public RoleBuilder WithCanCreateAllOnAllResources()
        {
            WithCanCreateAll(PermissionTarget.Category);
            WithCanCreateAll(PermissionTarget.News);
            WithCanCreateAll(PermissionTarget.Role);
            WithCanCreateAll(PermissionTarget.Permission);
            WithCanCreateAll(PermissionTarget.Account);
            return this;
        }

        public RoleBuilder WithCanDeleteAllOnAllResources()
        {
            WithCanDeleteAll(PermissionTarget.Category);
            WithCanDeleteAll(PermissionTarget.News);
            WithCanDeleteAll(PermissionTarget.Role);
            WithCanDeleteAll(PermissionTarget.Permission);
            WithCanDeleteAll(PermissionTarget.Account);
            return this;
        }

        public RoleBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public RoleBuilder WithCanReadAll(PermissionTarget target)
        {
            _permissions.Add(new Permission
            {
                PermissionAction = PermissionAction.CanRead,
                PermissionTarget = target,
                PermissionRange = PermissionRange.All
            });
            return this;
        }

        public RoleBuilder WithCanUpdateOwn(PermissionTarget target)
        {
            _permissions.Add(new Permission
            {
                PermissionAction = PermissionAction.CanUpdate,
                PermissionTarget = target,
                PermissionRange = PermissionRange.Own
            });
            return this;
        }

        public RoleBuilder WithCanDeleteOwn(PermissionTarget target)
        {
            _permissions.Add(new Permission
            {
                PermissionAction = PermissionAction.CanDelete,
                PermissionTarget = target,
                PermissionRange = PermissionRange.Own
            });
            return this;
        }

        public RoleBuilder WithCanReadOwn(PermissionTarget target)
        {
            _permissions.Add(new Permission
            {
                PermissionAction = PermissionAction.CanRead,
                PermissionTarget = target,
                PermissionRange = PermissionRange.Own
            });
            return this;
        }

        public RoleBuilder WithCanCreateOwn(PermissionTarget target)
        {
            _permissions.Add(new Permission
            {
                PermissionAction = PermissionAction.CanCreate,
                PermissionTarget = target,
                PermissionRange = PermissionRange.Own
            });
            return this;
        }


        public RoleBuilder WithCanUpdateAll(PermissionTarget target)
        {
            _permissions.Add(new Permission
            {
                PermissionAction = PermissionAction.CanUpdate,
                PermissionTarget = target,
                PermissionRange = PermissionRange.All
            });
            return this;
        }

        public RoleBuilder WithCanDeleteAll(PermissionTarget target)
        {
            _permissions.Add(new Permission
            {
                PermissionAction = PermissionAction.CanDelete,
                PermissionTarget = target,
                PermissionRange = PermissionRange.All
            });
            return this;
        }

        public RoleBuilder WithCanCreateAll(PermissionTarget target)
        {
            _permissions.Add(new Permission
            {
                PermissionAction = PermissionAction.CanCreate,
                PermissionTarget = target,
                PermissionRange = PermissionRange.All
            });
            return this;
        }

        public async Task<Role> Build()
        {
            var role = new Role() { Name = _name ?? Guid.NewGuid().ToString() };
            await _roleManager.CreateAsync(role);
            foreach (var permission in _permissions)
            {
                await _roleManager.AddClaimAsync(role,
                    new Claim("Permission", JsonSerializer.Serialize(permission)));
            }
            return role;
        }
    }
}
