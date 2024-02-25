using AutoMapper;

namespace Server.Models.DTOs.Category.Converters
{
    /// <summary>
    /// AutoMapper converter used to enable the conversion of <see cref="UpdateCategoryDto"/> to <see cref="Category"/>.
    /// </summary>
    public class UpdateCategoryConverter : ITypeConverter<UpdateCategoryDto, Data.Category>
    {
        /// <inheritdoc />
        public Data.Category Convert(UpdateCategoryDto source, Data.Category destination,
            ResolutionContext context)
        {
            destination.Name = source.Name;
            return destination;
        }
    }
}
