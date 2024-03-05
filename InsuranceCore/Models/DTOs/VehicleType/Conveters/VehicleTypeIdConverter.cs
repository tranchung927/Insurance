using System;
using AutoMapper;
using InsuranceCore.Repositories.VehicleType;

namespace InsuranceCore.Models.DTOs.VehicleType.Conveters
{
	public class VehicleTypeIdConverter : ITypeConverter<int, Data.VehicleType>
    {
        private readonly IVehicleTypeRepository _repository;

        public VehicleTypeIdConverter(IVehicleTypeRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Data.VehicleType Convert(int source, Data.VehicleType destination, ResolutionContext context)
        {
            return _repository.Get(source);
        }
    }
}

