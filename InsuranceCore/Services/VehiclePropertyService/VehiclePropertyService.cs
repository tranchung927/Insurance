using System;
using AutoMapper;
using InsuranceCore.Models.DTOs.VehicleProperty;
using InsuranceCore.Repositories.VehicleProperty;
using InsuranceCore.Repositories.UnitOfWork;
using InsuranceCore.Specifications;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;

namespace InsuranceCore.Services.VehiclePropertyService
{
	public class VehiclePropertyService : IVehiclePropertyService
    {
        private readonly IVehiclePropertyRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VehiclePropertyService(IVehiclePropertyRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetVehiclePropertyDto>> GetAllVehicleProperties()
        {
            return (await _repository.GetAllAsync()).Select(x => _mapper.Map<GetVehiclePropertyDto>(x)).ToList();
        }

        public async Task<IEnumerable<GetVehiclePropertyDto>> GetVehicleProperties(FilterSpecification<Data.VehicleProperty>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Data.VehicleProperty>? sortSpecification = null)
        {
            return (await _repository.GetAsync(filterSpecification, pagingSpecification, sortSpecification)).Select(x => _mapper.Map<GetVehiclePropertyDto>(x));
        }

        public async Task<int> CountVehiclePropertysWhere(FilterSpecification<Data.VehicleProperty>? filterSpecification = null)
        {
            return await _repository.CountWhereAsync(filterSpecification);
        }

        public async Task<GetVehiclePropertyDto> GetVehicleProperty(int id)
        {
            return _mapper.Map<GetVehiclePropertyDto>(await _repository.GetAsync(id));
        }

        public async Task<GetVehiclePropertyDto> AddVehicleProperty(AddVehiclePropertyDto vehicleProperty)
        {
            var result = await _repository.AddAsync(_mapper.Map<Data.VehicleProperty>(vehicleProperty));
            _unitOfWork.Save();
            return _mapper.Map<GetVehiclePropertyDto>(result);
        }

        public async Task UpdateVehicleProperty(UpdateVehiclePropertyDto vehicleProperty)
        {
            var VehiclePropertyEntity = await _repository.GetAsync(vehicleProperty.Id);
            _mapper.Map(vehicleProperty, VehiclePropertyEntity);
            _unitOfWork.Save();
        }

        public async Task DeleteVehicleProperty(int id)
        {
            await _repository.RemoveAsync(await _repository.GetAsync(id));
            _unitOfWork.Save();
        }
    }
}

