using System;
using AutoMapper;
using InsuranceCore.Repositories.HouseType;

namespace InsuranceCore.Models.DTOs.HouseType.Converters
{
	public class HouseTypeIdConverter : ITypeConverter<int, Data.HouseType>
    {
        private readonly IHouseTypeRepository _repository;

        public HouseTypeIdConverter(IHouseTypeRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Data.HouseType Convert(int source, Data.HouseType destination, ResolutionContext context)
        {
            return _repository.Get(source);
        }
    }
}

