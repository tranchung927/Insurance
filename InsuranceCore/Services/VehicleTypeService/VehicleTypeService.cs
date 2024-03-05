using System;
using AutoMapper;
using InsuranceCore.Models.DTOs.VehicleType;
using InsuranceCore.Repositories.UnitOfWork;
using InsuranceCore.Repositories.VehicleType;
using InsuranceCore.Services.VehicleTypeService;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.VehicleTypeService
{
	public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IVehicleTypeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VehicleTypeService(IVehicleTypeRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetVehicleTypeDto>> GetAllVehicleTypes()
        {
            return (await _repository.GetAllAsync()).Select(x => _mapper.Map<GetVehicleTypeDto>(x)).ToList();
        }

        public async Task<IEnumerable<GetVehicleTypeDto>> GetVehicleTypes(FilterSpecification<Data.VehicleType>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.VehicleType>? sortSpecification = null)
        {
            return (await _repository.GetAsync(filterSpecification, pagingSpecification, sortSpecification)).Select(x => _mapper.Map<GetVehicleTypeDto>(x));
        }

        public async Task<int> CountVehicleTypesWhere(FilterSpecification<Data.VehicleType>? filterSpecification = null)
        {
            return await _repository.CountWhereAsync(filterSpecification);
        }

        public async Task<GetVehicleTypeDto> GetVehicleType(int id)
        {
            return _mapper.Map<GetVehicleTypeDto>(await _repository.GetAsync(id));
        }

        public async Task<GetVehicleTypeDto> AddVehicleType(AddVehicleTypeDto vehicleType)
        {
            var result = await _repository.AddAsync(_mapper.Map<Data.VehicleType>(vehicleType));
            _unitOfWork.Save();
            return _mapper.Map<GetVehicleTypeDto>(result);
        }

        public async Task UpdateVehicleType(UpdateVehicleTypeDto vehicleType)
        {
            var VehicleTypeEntity = await _repository.GetAsync(vehicleType.Id);
            _mapper.Map(vehicleType, VehicleTypeEntity);
            _unitOfWork.Save();
        }

        public async Task DeleteVehicleType(int id)
        {
            await _repository.RemoveAsync(await _repository.GetAsync(id));
            _unitOfWork.Save();
        }
    }
}

