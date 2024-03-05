using System;
using AutoMapper;
using InsuranceCore.Data;
using InsuranceCore.Models.DTOs.HouseCoefficient;
using InsuranceCore.Repositories.HouseCoefficient;
using InsuranceCore.Repositories.UnitOfWork;
using InsuranceCore.Services.HouseCoefficient;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.HouseCoefficient
{
	public class HouseCoefficientService : IHouseCoefficientService
    {
        private readonly IHouseCoefficientRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HouseCoefficientService(IHouseCoefficientRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetHouseCoefficientDto>> GetAllHouseCoefficients()
        {
            return (await _repository.GetAllAsync()).Select(x => _mapper.Map<GetHouseCoefficientDto>(x)).ToList();
        }

        public async Task<IEnumerable<GetHouseCoefficientDto>> GetHouseCoefficients(FilterSpecification<Data.HouseCoefficient>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.HouseCoefficient>? sortSpecification = null)
        {
            return (await _repository.GetAsync(filterSpecification, pagingSpecification, sortSpecification)).Select(x => _mapper.Map<GetHouseCoefficientDto>(x));
        }

        public async Task<int> CountHouseCoefficientsWhere(FilterSpecification<Data.HouseCoefficient>? filterSpecification = null)
        {
            return await _repository.CountWhereAsync(filterSpecification);
        }

        public async Task<GetHouseCoefficientDto> GetHouseCoefficient(int id)
        {
            return _mapper.Map<GetHouseCoefficientDto>(await _repository.GetAsync(id));
        }

        public async Task<GetHouseCoefficientDto> AddHouseCoefficient(AddHouseCoefficientDto houseCoefficient)
        {
            var result = await _repository.AddAsync(_mapper.Map<Data.HouseCoefficient>(houseCoefficient));
            _unitOfWork.Save();
            return _mapper.Map<GetHouseCoefficientDto>(result);
        }

        public async Task UpdateHouseCoefficient(UpdateHouseCoefficientDto houseCoefficient)
        {
            var HouseCoefficientEntity = await _repository.GetAsync(houseCoefficient.Id);
            _mapper.Map(houseCoefficient, HouseCoefficientEntity);
            _unitOfWork.Save();
        }

        public async Task DeleteHouseCoefficient(int id)
        {
            await _repository.RemoveAsync(await _repository.GetAsync(id));
            _unitOfWork.Save();
        }
    }
}

