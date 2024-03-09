using AutoMapper;
using InsuranceCore.Repositories.HouseRiskCoefficient;

namespace InsuranceCore.Models.DTOs.HouseRiskCoefficient.Converters
{
    public class HouseRiskCoefficientIdConverter : ITypeConverter<int, Data.HouseRiskCoefficient>
    {
        private readonly IHouseRiskCoefficientRepository _repository;

        public HouseRiskCoefficientIdConverter(IHouseRiskCoefficientRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Data.HouseRiskCoefficient Convert(int source, Data.HouseRiskCoefficient destination, ResolutionContext context)
        {
            return _repository.Get(source);
        }
    }
}
