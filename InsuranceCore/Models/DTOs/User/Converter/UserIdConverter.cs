using AutoMapper;
using InsuranceCore.Repositories.User;

namespace InsuranceCore.Models.DTOs.User.Converter
{
    /// <summary>
    /// AutoMapper converter used to enable the conversion of <see cref="User"/> to its resource Id.
    /// </summary>
    public class UserIdConverter : ITypeConverter<int, Data.User>
    {
        private readonly IUserRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserIdConverter"/> class.
        /// </summary>
        /// <param name="repository"></param>
        public UserIdConverter(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Data.User Convert(int source, Data.User destination,
            ResolutionContext context)
        {
            return _repository.Get(source);
        }
    }
}
