using System;
using AutoMapper;
using InsuranceCore.Repositories.DeathRate;
using InsuranceCore.Repositories.Workplace;

namespace InsuranceCore.Models.DTOs.Workplace.Converters
{
	public class WorkplaceIdConverter : ITypeConverter<int, Data.Workplace>
    {
        private readonly IWorkplaceRepository _repository;

        public WorkplaceIdConverter(IWorkplaceRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Data.Workplace Convert(int source, Data.Workplace destination, ResolutionContext context)
        {
            return _repository.Get(source);
        }
    }
}

