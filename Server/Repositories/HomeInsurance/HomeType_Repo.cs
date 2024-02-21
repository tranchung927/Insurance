using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.HomeInsurance;

namespace Server.Repositories.HomeInsurance
{
    public class HomeType_Repo : IRepository<HomeTypeModel>
    {
        private readonly Web_Context _context;
        private readonly IMapper _mapper;

        public HomeType_Repo(Web_Context contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        Task<HomeTypeModel> IRepository<HomeTypeModel>.AddNew(HomeTypeModel entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<HomeTypeModel>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<HomeTypeModel>> IRepository<HomeTypeModel>.GetAll()
        {
            var EntityList = await _context.HomeType ?.ToListAsync();
            return _mapper.Map<List<HomeTypeModel>>(EntityList);
        }

        Task<HomeTypeModel> IRepository<HomeTypeModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<HomeTypeModel>.Update(HomeTypeModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
