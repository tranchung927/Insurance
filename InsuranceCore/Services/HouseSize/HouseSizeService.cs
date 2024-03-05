using System;
using AutoMapper;
using InsuranceCore.Data;
using InsuranceCore.Models.DTOs.HouseSize;
using InsuranceCore.Repositories.HouseSize;
using InsuranceCore.Repositories.UnitOfWork;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.HouseSize
{
	public class HouseSizeService : IHouseSizeService
    {
        private readonly IHouseSizeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HouseSizeService(IHouseSizeRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetHouseSizeDto>> GetAllHouseSizes()
        {
            return (await _repository.GetAllAsync()).Select(x => _mapper.Map<GetHouseSizeDto>(x)).ToList();
        }

        public async Task<IEnumerable<GetHouseSizeDto>> GetHouseSizes(FilterSpecification<Data.HouseSize>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.HouseSize>? sortSpecification = null)
        {
            return (await _repository.GetAsync(filterSpecification, pagingSpecification, sortSpecification)).Select(x => _mapper.Map<GetHouseSizeDto>(x));
        }

        public async Task<int> CountHouseSizesWhere(FilterSpecification<Data.HouseSize>? filterSpecification = null)
        {
            return await _repository.CountWhereAsync(filterSpecification);
        }

        public async Task<GetHouseSizeDto> GetHouseSize(int id)
        {
            return _mapper.Map<GetHouseSizeDto>(await _repository.GetAsync(id));
        }

        public async Task<GetHouseSizeDto> AddHouseSize(AddHouseSizeDto HouseSize)
        {
            var result = await _repository.AddAsync(_mapper.Map<Data.HouseSize>(HouseSize));
            _unitOfWork.Save();
            return _mapper.Map<GetHouseSizeDto>(result);
        }

        public async Task UpdateHouseSize(UpdateHouseSizeDto houseSize)
        {
            var HouseSizeEntity = await _repository.GetAsync(houseSize.Id);
            _mapper.Map(houseSize, HouseSizeEntity);
            _unitOfWork.Save();
        }

        public async Task DeleteHouseSize(int id)
        {
            await _repository.RemoveAsync(await _repository.GetAsync(id));
            _unitOfWork.Save();
        }
    }
}

