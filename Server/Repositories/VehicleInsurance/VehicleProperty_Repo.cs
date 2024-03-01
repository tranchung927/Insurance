using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.VehicleInsurance;
using Server.Models.VehicleInsurance;

namespace Server.Repositories.VehicleInsurance
{
    public class VehicleProperty_Repo : IRepository<VehiclePropertyModel>
    {
        private readonly Web_Context _context;
        private readonly IMapper _mapper;

        public VehicleProperty_Repo(Web_Context contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        Task<VehiclePropertyModel> IRepository<VehiclePropertyModel>.AddNew(VehiclePropertyModel entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<VehiclePropertyModel>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<VehiclePropertyModel>> IRepository<VehiclePropertyModel>.GetAll()
        {
            var EntityList = await _context.VehicleProperty?.ToListAsync();
            return _mapper.Map<List<VehiclePropertyModel>>(EntityList);
        }

        Task<VehiclePropertyModel> IRepository<VehiclePropertyModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<VehiclePropertyModel>.Update(VehiclePropertyModel entity)
        {
            throw new NotImplementedException();
        }
    }

}
