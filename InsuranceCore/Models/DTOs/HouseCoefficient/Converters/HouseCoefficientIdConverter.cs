using System;
using AutoMapper;
using InsuranceCore.Repositories.HouseCoefficient;

namespace InsuranceCore.Models.DTOs.HouseCoefficient.Converters
{
	public class HouseCoefficientIdConverter : ITypeConverter<int, Data.HouseCoefficient>
    {
        private readonly IHouseCoefficientRepository _repository;

        public HouseCoefficientIdConverter(IHouseCoefficientRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Data.HouseCoefficient Convert(int source, Data.HouseCoefficient destination, ResolutionContext context)
        {
            return _repository.Get(source);
        }
    }
}

