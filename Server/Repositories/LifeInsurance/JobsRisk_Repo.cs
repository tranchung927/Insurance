using AutoMapper;
using Server.Data;
using Server.Models.LifeInsurance;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories.LifeInsurance
{
    public class JobsRisk_Repo : IRepository<JobsRiskModel>
    {
        private readonly Web_Context _context;
        private readonly IMapper _mapper;

        public JobsRisk_Repo(Web_Context contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        Task<JobsRiskModel> IRepository<JobsRiskModel>.AddNew(JobsRiskModel entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<JobsRiskModel>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<JobsRiskModel>> IRepository<JobsRiskModel>.GetAll()
        {
            var EntityList = await _context.JobsRisk ?.ToListAsync();
            return _mapper.Map<List<JobsRiskModel>>(EntityList);
        }

        Task<JobsRiskModel> IRepository<JobsRiskModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<JobsRiskModel>.Update(JobsRiskModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
