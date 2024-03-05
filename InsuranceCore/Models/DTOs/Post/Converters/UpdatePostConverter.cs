using AutoMapper;
using InsuranceCore.Data.JoiningEntity;
using InsuranceCore.Repositories.Category;
using InsuranceCore.Repositories.User;

namespace InsuranceCore.Models.DTOs.Post.Converters
{
    /// <summary>
    /// AutoMapper converter used to enable the conversion of <see cref="UpdatePostConverter"/> to <see cref="Post"/>.
    /// </summary>
    public class UpdatePostConverter : ITypeConverter<UpdatePostDto, Data.Post>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatePostConverter"/> class.
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="categoryRepository"></param>
        public UpdatePostConverter(IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        /// <inheritdoc />
        public Data.Post Convert(UpdatePostDto source, Data.Post destination,
            ResolutionContext context)
        {
            destination.Author = _userRepository.Get(source.Author);
            destination.Category = _categoryRepository.Get(source.Category);
            destination.Content = source.Content;
            destination.Name = source.Name;
            destination.ThumbnailUrl = string.IsNullOrEmpty(source.ThumbnailUrl) ? null : source.ThumbnailUrl;
            return destination;
        }
    }
}
