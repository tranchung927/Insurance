using System;
using InsuranceCore.Data;
using InsuranceCore.Models.DTOs.HouseSize;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.HouseSize
{
	public interface IHouseSizeService
	{
        Task<IEnumerable<GetHouseSizeDto>> GetAllHouseSizes();

        public Task<IEnumerable<GetHouseSizeDto>> GetHouseSizes(FilterSpecification<Data.HouseSize>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.HouseSize>? sortSpecification = null);

        public Task<int> CountHouseSizesWhere(FilterSpecification<Data.HouseSize>? filterSpecification = null);

        Task<GetHouseSizeDto> GetHouseSize(int id);

        Task<GetHouseSizeDto> AddHouseSize(AddHouseSizeDto houseSize);

        Task UpdateHouseSize(UpdateHouseSizeDto houseSize);

        Task DeleteHouseSize(int id);
    }
}

