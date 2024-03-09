using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;
using InsuranceCore.Specifications;
using InsuranceCore.Models.DTOs.HouseRiskCoefficient;

namespace InsuranceCore.Services.HouseRiskCoefficient
{
    public interface IHouseRiskCoefficientService
    {
        Task<IEnumerable<GetHouseRiskCoefficientDto>> GetAllHouseRiskCoefficients();

        public Task<IEnumerable<GetHouseRiskCoefficientDto>> GetHouseRiskCoefficients(FilterSpecification<Data.HouseRiskCoefficient>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.HouseRiskCoefficient>? sortSpecification = null);

        public Task<int> CountHouseRiskCoefficientsWhere(FilterSpecification<Data.HouseRiskCoefficient>? filterSpecification = null);

        Task<GetHouseRiskCoefficientDto> GetHouseRiskCoefficient(int id);

        Task<GetHouseRiskCoefficientDto> AddHouseRiskCoefficient(AddHouseRiskCoefficientDto houseRiskCoefficient);

        Task UpdateHouseRiskCoefficient(UpdateHouseRiskCoefficientDto houseRiskCoefficient);

        Task DeleteHouseRiskCoefficient(int id);
    }
}
