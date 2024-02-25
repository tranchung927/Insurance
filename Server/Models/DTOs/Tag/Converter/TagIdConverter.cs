using AutoMapper;
using Server.Repositories.Tag;

namespace Server.Models.DTOs.Tag.Converter
{
    /// <summary>
    /// AutoMapper converter used to enable the conversion of <see cref="Tag"/> to its resource Id.
    /// </summary>
    public class TagIdConverter : ITypeConverter<int, Data.Tag>
    {
        private readonly ITagRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagIdConverter"/> class.
        /// </summary>
        /// <param name="repository"></param>
        public TagIdConverter(ITagRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Data.Tag Convert(int source, Data.Tag destination, ResolutionContext context)
        {
            return _repository.Get(source);
        }
    }
}
