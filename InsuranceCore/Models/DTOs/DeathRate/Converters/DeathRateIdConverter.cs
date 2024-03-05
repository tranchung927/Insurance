using System;
using AutoMapper;
using InsuranceCore.Repositories.DeathRate;

namespace InsuranceCore.Models.DTOs.DeathRate.Converters
{
	public class DeathRateIdConverter : ITypeConverter<int, Data.DeathRate>
    {
        private readonly IDeathRateRepository _repository;

        public DeathRateIdConverter(IDeathRateRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Data.DeathRate Convert(int source, Data.DeathRate destination, ResolutionContext context)
        {
            return _repository.Get(source);
        }
    }
}

