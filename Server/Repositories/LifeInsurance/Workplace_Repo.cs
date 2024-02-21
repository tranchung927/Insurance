using AutoMapper;
using Server.Data;
using Server.Models.LifeInsurance;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories.LifeInsurance
{
    public class Workplace_Repo : IRepository<WorkplaceModel>
    {
        private readonly Web_Context _context;
        private readonly IMapper _mapper;

        public Workplace_Repo(Web_Context contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }
        Task<WorkplaceModel> IRepository<WorkplaceModel>.AddNew(WorkplaceModel entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<WorkplaceModel>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<WorkplaceModel>> IRepository<WorkplaceModel>.GetAll()
        {
            var EntityList = await _context.Workplace ?.ToListAsync();
            return _mapper.Map<List<WorkplaceModel>>(EntityList);
        }

        Task<WorkplaceModel> IRepository<WorkplaceModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<WorkplaceModel>.Update(WorkplaceModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
