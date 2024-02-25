﻿using AutoMapper;
using Server.Data.Permission;

namespace Server.Models.DTOs.Permission.Converters
{
    /// <summary>
    /// AutoMapper converter used to enable the conversion of <see cref="PermissionAction"/> to <see cref="PermissionActionDto"/>.
    /// </summary>
    public class PermissionActionConverter : ITypeConverter<PermissionAction, PermissionActionDto>
    {
        /// <inheritdoc />
        public PermissionActionDto Convert(PermissionAction source, PermissionActionDto destination,
            ResolutionContext context)
        {
            destination ??= new PermissionActionDto();
            destination.Name = source.ToString();
            destination.Id = (int)source;
            return destination;
        }
    }
}
