using System;
using InsuranceCore.Models.DTOs.HouseType;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.HouseType
{
	public interface IHouseTypeService
	{
        Task<IEnumerable<GetHouseTypeDto>> GetAllHouseTypes();

        public Task<IEnumerable<GetHouseTypeDto>> GetHouseTypes(FilterSpecification<Data.HouseType>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.HouseType>? sortSpecification = null);

        public Task<int> CountHouseTypesWhere(FilterSpecification<Data.HouseType>? filterSpecification = null);

        Task<GetHouseTypeDto> GetHouseType(int id);

        Task<GetHouseTypeDto> AddHouseType(AddHouseTypeDto houseType);

        Task UpdateHouseType(UpdateHouseTypeDto houseType);

        Task DeleteHouseType(int id);
    }
}

