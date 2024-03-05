using System;
using AutoMapper;
using InsuranceCore.Models.DTOs.HouseType;
using InsuranceCore.Repositories.HouseType;
using InsuranceCore.Repositories.UnitOfWork;
using InsuranceCore.Services.HouseType;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.HouseType
{
	public class HouseTypeService : IHouseTypeService
    {
        private readonly IHouseTypeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HouseTypeService(IHouseTypeRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetHouseTypeDto>> GetAllHouseTypes()
        {
            return (await _repository.GetAllAsync()).Select(x => _mapper.Map<GetHouseTypeDto>(x)).ToList();
        }

        public async Task<IEnumerable<GetHouseTypeDto>> GetHouseTypes(FilterSpecification<Data.HouseType>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.HouseType>? sortSpecification = null)
        {
            return (await _repository.GetAsync(filterSpecification, pagingSpecification, sortSpecification)).Select(x => _mapper.Map<GetHouseTypeDto>(x));
        }

        public async Task<int> CountHouseTypesWhere(FilterSpecification<Data.HouseType>? filterSpecification = null)
        {
            return await _repository.CountWhereAsync(filterSpecification);
        }

        public async Task<GetHouseTypeDto> GetHouseType(int id)
        {
            return _mapper.Map<GetHouseTypeDto>(await _repository.GetAsync(id));
        }

        public async Task<GetHouseTypeDto> AddHouseType(AddHouseTypeDto houseType)
        {
            var result = await _repository.AddAsync(_mapper.Map<Data.HouseType>(houseType));
            _unitOfWork.Save();
            return _mapper.Map<GetHouseTypeDto>(result);
        }

        public async Task UpdateHouseType(UpdateHouseTypeDto houseType)
        {
            var HouseTypeEntity = await _repository.GetAsync(houseType.Id);
            _mapper.Map(houseType, HouseTypeEntity);
            _unitOfWork.Save();
        }

        public async Task DeleteHouseType(int id)
        {
            await _repository.RemoveAsync(await _repository.GetAsync(id));
            _unitOfWork.Save();
        }
    }
}

