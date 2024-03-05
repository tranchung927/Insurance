using System;
using InsuranceCore.Models.DTOs.VehicleType;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.VehicleTypeService
{
	public interface IVehicleTypeService
	{
        Task<IEnumerable<GetVehicleTypeDto>> GetAllVehicleTypes();

        public Task<IEnumerable<GetVehicleTypeDto>> GetVehicleTypes(FilterSpecification<Data.VehicleType>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.VehicleType>? sortSpecification = null);

        public Task<int> CountVehicleTypesWhere(FilterSpecification<Data.VehicleType>? filterSpecification = null);

        Task<GetVehicleTypeDto> GetVehicleType(int id);

        Task<GetVehicleTypeDto> AddVehicleType(AddVehicleTypeDto vehicleType);

        Task UpdateVehicleType(UpdateVehicleTypeDto vehicleType);

        Task DeleteVehicleType(int id);
    }
}

