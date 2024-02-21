using AutoMapper;
using Server.Data;
using Server.Models.ClientSupport;
using Server.Models.LifeInsurance;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories.LifeInsurance
{
    public class DeathRate_Repo : IRepository<DeathRateModel>
    {
        private readonly Web_Context _context;
        private readonly IMapper _mapper;

        public DeathRate_Repo(Web_Context contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        Task<DeathRateModel> IRepository<DeathRateModel>.AddNew(DeathRateModel entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<DeathRateModel>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<DeathRateModel>> IRepository<DeathRateModel>.GetAll()
        {
            var EntityList = await _context.DeathRate?.ToListAsync();
            return _mapper.Map<List<DeathRateModel>>(EntityList);
        }

        Task<DeathRateModel> IRepository<DeathRateModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<DeathRateModel>.Update(DeathRateModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
