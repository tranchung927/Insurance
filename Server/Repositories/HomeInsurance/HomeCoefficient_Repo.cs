using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.ClientSupport;
using Server.Models.HomeInsurance;

namespace Server.Repositories.HomeInsurance
{
    public class HomeCoefficient_Repo : IRepository<HomeCoefficientModel>
    {
        private readonly Web_Context _context;
        private readonly IMapper _mapper;

        public HomeCoefficient_Repo(Web_Context contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }


        Task<HomeCoefficientModel> IRepository<HomeCoefficientModel>.AddNew(HomeCoefficientModel entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<HomeCoefficientModel>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<HomeCoefficientModel>> IRepository<HomeCoefficientModel>.GetAll()
        {
            var EntityList = await _context.HomeCoefficient ?.ToListAsync();
            return _mapper.Map<List<HomeCoefficientModel>>(EntityList);
        }

        Task<HomeCoefficientModel> IRepository<HomeCoefficientModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<HomeCoefficientModel>.Update(HomeCoefficientModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
