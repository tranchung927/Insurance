using System;
using AutoMapper;
using InsuranceCore.Repositories.HouseSize;

namespace InsuranceCore.Models.DTOs.HouseSize.Converters
{
	public class HouseSizeIdConverter : ITypeConverter<int, Data.HouseSize>
    {
        private readonly IHouseSizeRepository _repository;

        public HouseSizeIdConverter(IHouseSizeRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Data.HouseSize Convert(int source, Data.HouseSize destination, ResolutionContext context)
        {
            return _repository.Get(source);
        }
    }
}

