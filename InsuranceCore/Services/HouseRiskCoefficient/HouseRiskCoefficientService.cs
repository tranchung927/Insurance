using AutoMapper;
using InsuranceCore.Models.DTOs.HouseRiskCoefficient;
using InsuranceCore.Repositories.HouseRiskCoefficient;
using InsuranceCore.Repositories.UnitOfWork;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;
using InsuranceCore.Specifications;

namespace InsuranceCore.Services.HouseRiskCoefficient
{
    public class HouseRiskCoefficientService : IHouseRiskCoefficientService
    {
        private readonly IHouseRiskCoefficientRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HouseRiskCoefficientService(IHouseRiskCoefficientRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetHouseRiskCoefficientDto>> GetAllHouseRiskCoefficients()
        {
            return (await _repository.GetAllAsync()).Select(x => _mapper.Map<GetHouseRiskCoefficientDto>(x)).ToList();
        }

        public async Task<IEnumerable<GetHouseRiskCoefficientDto>> GetHouseRiskCoefficients(FilterSpecification<Data.HouseRiskCoefficient>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.HouseRiskCoefficient>? sortSpecification = null)
        {
            return (await _repository.GetAsync(filterSpecification, pagingSpecification, sortSpecification)).Select(x => _mapper.Map<GetHouseRiskCoefficientDto>(x));
        }

        public async Task<int> CountHouseRiskCoefficientsWhere(FilterSpecification<Data.HouseRiskCoefficient>? filterSpecification = null)
        {
            return await _repository.CountWhereAsync(filterSpecification);
        }

        public async Task<GetHouseRiskCoefficientDto> GetHouseRiskCoefficient(int id)
        {
            return _mapper.Map<GetHouseRiskCoefficientDto>(await _repository.GetAsync(id));
        }

        public async Task<GetHouseRiskCoefficientDto> AddHouseRiskCoefficient(AddHouseRiskCoefficientDto houseRiskCoefficient)
        {
            var result = await _repository.AddAsync(_mapper.Map<Data.HouseRiskCoefficient>(houseRiskCoefficient));
            _unitOfWork.Save();
            return _mapper.Map<GetHouseRiskCoefficientDto>(result);
        }

        public async Task UpdateHouseRiskCoefficient(UpdateHouseRiskCoefficientDto houseRiskCoefficient)
        {
            var HouseRiskCoefficientEntity = await _repository.GetAsync(houseRiskCoefficient.Id);
            _mapper.Map(houseRiskCoefficient, HouseRiskCoefficientEntity);
            _unitOfWork.Save();
        }

        public async Task DeleteHouseRiskCoefficient(int id)
        {
            await _repository.RemoveAsync(await _repository.GetAsync(id));
            _unitOfWork.Save();
        }
    }
}
