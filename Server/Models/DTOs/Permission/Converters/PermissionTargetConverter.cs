using AutoMapper;
using Server.Data.Permission;

namespace Server.Models.DTOs.Permission.Converters
{
    /// <summary>
    /// AutoMapper converter used to enable the conversion of <see cref="PermissionTarget"/> to <see cref="PermissionTargetDto"/>.
    /// </summary>
    public class PermissionTargetConverter : ITypeConverter<PermissionTarget, PermissionTargetDto>
    {
        /// <inheritdoc />
        public PermissionTargetDto Convert(PermissionTarget source, PermissionTargetDto destination,
            ResolutionContext context)
        {
            destination ??= new PermissionTargetDto();
            destination.Name = source.ToString();
            destination.Id = (int)source;
            return destination;
        }
    }
}
