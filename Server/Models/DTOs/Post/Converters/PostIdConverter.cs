using AutoMapper;
using Server.Repositories.Post;

namespace Server.Models.DTOs.Post.Converters
{
    /// <summary>
    /// AutoMapper converter used to enable the conversion of <see cref="Post"/> to its resource Id.
    /// </summary>
    public class PostIdConverter : ITypeConverter<int, Data.Post>
    {
        private readonly IPostRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostIdConverter"/> class.
        /// </summary>
        /// <param name="repository"></param>
        public PostIdConverter(IPostRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Data.Post Convert(int source, Data.Post destination, ResolutionContext context)
        {
            return _repository.Get(source);
        }
    }
}
