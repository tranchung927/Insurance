using System;
using InsuranceCore.Models.DTOs.VehicleProperty;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.VehiclePropertyService
{
	public interface IVehiclePropertyService
	{
        Task<IEnumerable<GetVehiclePropertyDto>> GetAllVehicleProperties();

        public Task<IEnumerable<GetVehiclePropertyDto>> GetVehicleProperties(FilterSpecification<Data.VehicleProperty>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.VehicleProperty>? sortSpecification = null);

        public Task<int> CountVehiclePropertysWhere(FilterSpecification<Data.VehicleProperty>? filterSpecification = null);

        Task<GetVehiclePropertyDto> GetVehicleProperty(int id);

        Task<GetVehiclePropertyDto> AddVehicleProperty(AddVehiclePropertyDto vehicleProperty);

        Task UpdateVehicleProperty(UpdateVehiclePropertyDto vehicleProperty);

        Task DeleteVehicleProperty(int id);
    }
}

