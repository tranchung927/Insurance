﻿using Microsoft.AspNetCore.Authorization;
using InsuranceCore.Data.Permission;

namespace InsuranceCore.Authorization.Attributes
{
    /// <summary>
    ///  Attribute allowing to define the corresponding permission needed for an resource endpoint.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class PermissionWithPermissionRangeAllRequiredAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionWithPermissionRangeAllRequiredAttribute"/> class.
        /// </summary>
        /// <param name="permission"></param>
        /// <param name="permissionTarget"></param>
        public PermissionWithPermissionRangeAllRequiredAttribute(PermissionAction permission, PermissionTarget permissionTarget) : base("permission" + "." + permission + "." + permissionTarget + "." + PermissionRange.All)
        {
        }
    }
}
