using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.VehicleInsurance;

namespace Server.Repositories.VehicleInsurance
{
    public class VehicleType_Repo : IRepository<VehicleTypeModel>
    {
        private readonly Web_Context _context;
        private readonly IMapper _mapper;

        public VehicleType_Repo(Web_Context contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        Task<VehicleTypeModel> IRepository<VehicleTypeModel>.AddNew(VehicleTypeModel entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<VehicleTypeModel>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<VehicleTypeModel>> IRepository<VehicleTypeModel>.GetAll()
        {
            var EntityList = await _context.VehicleType?.ToListAsync();
            return _mapper.Map<List<VehicleTypeModel>>(EntityList);
        }

        Task<VehicleTypeModel> IRepository<VehicleTypeModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<VehicleTypeModel>.Update(VehicleTypeModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
