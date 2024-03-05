using System;
using AutoMapper;
using InsuranceCore.Repositories.VehicleProperty;

namespace InsuranceCore.Models.DTOs.VehicleProperty.Converters
{
	public class VehiclePropertyIdConveter : ITypeConverter<int, Data.VehicleProperty>
    {
        private readonly IVehiclePropertyRepository _repository;

        public VehiclePropertyIdConveter(IVehiclePropertyRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Data.VehicleProperty Convert(int source, Data.VehicleProperty destination, ResolutionContext context)
        {
            return _repository.Get(source);
        }
    }
}

