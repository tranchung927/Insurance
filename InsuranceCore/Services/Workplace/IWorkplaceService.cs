using System;
using InsuranceCore.Data;
using InsuranceCore.Models.DTOs.VehicleType;
using InsuranceCore.Models.DTOs.Workplace;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.Workplace
{
	public interface IWorkplaceService
	{
        Task<IEnumerable<GetWorkplaceDto>> GetAllWorkplaces();

        public Task<IEnumerable<GetWorkplaceDto>> GetWorkplaces(FilterSpecification<Data.Workplace>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.Workplace>? sortSpecification = null);

        public Task<int> CountWorkplacesWhere(FilterSpecification<Data.Workplace>? filterSpecification = null);

        Task<GetWorkplaceDto> GetWorkplace(int id);

        Task<GetWorkplaceDto> AddWorkplace(AddWorkplaceDto workplace);
        Task UpdateWorkplace(UpdateWorkplaceDto workplace);

        Task DeleteWorkplace(int id);
    }
}

