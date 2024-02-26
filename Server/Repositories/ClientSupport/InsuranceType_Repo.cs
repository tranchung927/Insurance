using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.ClientSupport;

namespace Server.Repositories.ClientSupport
{
    public class InsuranceType_Repo : IRepository<InsuranceTypeModel>
    {
        private readonly Web_Context _context;
        private readonly IMapper _mapper;

        public InsuranceType_Repo(Web_Context contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        Task<InsuranceTypeModel> IRepository<InsuranceTypeModel>.AddNew(InsuranceTypeModel entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<InsuranceTypeModel>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<InsuranceTypeModel>> IRepository<InsuranceTypeModel>.GetAll()
        {
            var EntityList = await _context.InsuranceType?.ToListAsync();
            return _mapper.Map<List<InsuranceTypeModel>>(EntityList);
        }

        Task<InsuranceTypeModel> IRepository<InsuranceTypeModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<InsuranceTypeModel>.Update(InsuranceTypeModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
