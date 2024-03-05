using System;
using InsuranceCore.Models.DTOs.DeathRate;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.DeathRate
{
	public interface IDeathRateService
	{
        Task<IEnumerable<GetDeathRateDto>> GetAllDeathRates();

        public Task<IEnumerable<GetDeathRateDto>> GetDeathRates(FilterSpecification<Data.DeathRate>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.DeathRate>? sortSpecification = null);

        public Task<int> CountDeathRatesWhere(FilterSpecification<Data.DeathRate>? filterSpecification = null);

        Task<GetDeathRateDto> GetDeathRate(int id);

        Task<GetDeathRateDto> AddDeathRate(AddDeathRateDto deathRate);

        Task UpdateDeathRate(UpdateDeathRateDto deathRate);

        Task DeleteDeathRate(int id);
    }
}

