using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.HomeInsurance;

namespace Server.Repositories.HomeInsurance
{
    public class SizeType_Repo : IRepository<SizeTypeModel>
    {
        private readonly Web_Context _context;
        private readonly IMapper _mapper;

        public SizeType_Repo(Web_Context contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        Task<SizeTypeModel> IRepository<SizeTypeModel>.AddNew(SizeTypeModel entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<SizeTypeModel>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<SizeTypeModel>> IRepository<SizeTypeModel>.GetAll()
        {
            var EntityList = await _context.SizeType ?.ToListAsync();
            return _mapper.Map<List<SizeTypeModel>>(EntityList);
        }

        Task<SizeTypeModel> IRepository<SizeTypeModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<SizeTypeModel>.Update(SizeTypeModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
