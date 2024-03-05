using System;
using InsuranceCore.Models.DTOs.HouseCoefficient;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.HouseCoefficient
{
	public interface IHouseCoefficientService
	{
        Task<IEnumerable<GetHouseCoefficientDto>> GetAllHouseCoefficients();

        public Task<IEnumerable<GetHouseCoefficientDto>> GetHouseCoefficients(FilterSpecification<Data.HouseCoefficient>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.HouseCoefficient>? sortSpecification = null);

        public Task<int> CountHouseCoefficientsWhere(FilterSpecification<Data.HouseCoefficient>? filterSpecification = null);

        Task<GetHouseCoefficientDto> GetHouseCoefficient(int id);

        Task<GetHouseCoefficientDto> AddHouseCoefficient(AddHouseCoefficientDto houseCoefficient);

        Task UpdateHouseCoefficient(UpdateHouseCoefficientDto houseCoefficient);

        Task DeleteHouseCoefficient(int id);
    }
}

