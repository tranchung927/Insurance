using System;
using AutoMapper;
using InsuranceCore.Data;
using InsuranceCore.Models.DTOs.Workplace;
using InsuranceCore.Repositories.Workplace;
using InsuranceCore.Repositories.UnitOfWork;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;
using InsuranceCore.Models.DTOs.VehicleType;

namespace InsuranceCore.Services.Workplace
{
	public class WorkplaceService : IWorkplaceService
    {
        private readonly IWorkplaceRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public WorkplaceService(IWorkplaceRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetWorkplaceDto>> GetAllWorkplaces()
        {
            return (await _repository.GetAllAsync()).Select(x => _mapper.Map<GetWorkplaceDto>(x)).ToList();
        }

        public async Task<IEnumerable<GetWorkplaceDto>> GetWorkplaces(FilterSpecification<Data.Workplace>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.Workplace>? sortSpecification = null)
        {
            return (await _repository.GetAsync(filterSpecification, pagingSpecification, sortSpecification)).Select(x => _mapper.Map<GetWorkplaceDto>(x));
        }

        public async Task<int> CountWorkplacesWhere(FilterSpecification<Data.Workplace>? filterSpecification = null)
        {
            return await _repository.CountWhereAsync(filterSpecification);
        }

        public async Task<GetWorkplaceDto> GetWorkplace(int id)
        {
            return _mapper.Map<GetWorkplaceDto>(await _repository.GetAsync(id));
        }

        public async Task<GetWorkplaceDto> AddWorkplace(AddWorkplaceDto workplace)
        {
            var result = await _repository.AddAsync(_mapper.Map<Data.Workplace>(workplace));
            _unitOfWork.Save();
            return _mapper.Map<GetWorkplaceDto>(result);
        }

        public async Task UpdateWorkplace(UpdateWorkplaceDto workplace)
        {
            var WorkplaceEntity = await _repository.GetAsync(workplace.Id);
            _mapper.Map(workplace, WorkplaceEntity);
            _unitOfWork.Save();
        }

        public async Task DeleteWorkplace(int id)
        {
            await _repository.RemoveAsync(await _repository.GetAsync(id));
            _unitOfWork.Save();
        }
    }
}

