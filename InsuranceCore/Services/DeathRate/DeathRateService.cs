using System;
using AutoMapper;
using InsuranceCore.Models.DTOs.DeathRate;
using InsuranceCore.Repositories.DeathRate;
using InsuranceCore.Repositories.UnitOfWork;
using InsuranceCore.Services.DeathRate;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.DeathRate
{
	public class DeathRateService : IDeathRateService
    {
        private readonly IDeathRateRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeathRateService(IDeathRateRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetDeathRateDto>> GetAllDeathRates()
        {
            return (await _repository.GetAllAsync()).Select(x => _mapper.Map<GetDeathRateDto>(x)).ToList();
        }

        public async Task<IEnumerable<GetDeathRateDto>> GetDeathRates(FilterSpecification<Data.DeathRate>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.DeathRate>? sortSpecification = null)
        {
            return (await _repository.GetAsync(filterSpecification, pagingSpecification, sortSpecification)).Select(x => _mapper.Map<GetDeathRateDto>(x));
        }

        public async Task<int> CountDeathRatesWhere(FilterSpecification<Data.DeathRate>? filterSpecification = null)
        {
            return await _repository.CountWhereAsync(filterSpecification);
        }

        public async Task<GetDeathRateDto> GetDeathRate(int id)
        {
            return _mapper.Map<GetDeathRateDto>(await _repository.GetAsync(id));
        }

        public async Task<GetDeathRateDto> AddDeathRate(AddDeathRateDto deathRate)
        {
            var result = await _repository.AddAsync(_mapper.Map<Data.DeathRate>(deathRate));
            _unitOfWork.Save();
            return _mapper.Map<GetDeathRateDto>(result);
        }

        public async Task UpdateDeathRate(UpdateDeathRateDto deathRate)
        {
            var DeathRateEntity = await _repository.GetAsync(deathRate.Id);
            _mapper.Map(deathRate, DeathRateEntity);
            _unitOfWork.Save();
        }

        public async Task DeleteDeathRate(int id)
        {
            await _repository.RemoveAsync(await _repository.GetAsync(id));
            _unitOfWork.Save();
        }
    }
}

