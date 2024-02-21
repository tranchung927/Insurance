using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.HomeInsurance;

namespace Server.Repositories.HomeInsurance
{
    public class RiskCoefficient_Repo : IRepository<RiskCoefficientModel>
    {
        private readonly Web_Context _context;
        private readonly IMapper _mapper;

        public RiskCoefficient_Repo(Web_Context contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        Task<RiskCoefficientModel> IRepository<RiskCoefficientModel>.AddNew(RiskCoefficientModel entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<RiskCoefficientModel>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<RiskCoefficientModel>> IRepository<RiskCoefficientModel>.GetAll()
        {
            var EntityList = await _context.RiskCoefficient?.ToListAsync();
            return _mapper.Map<List<RiskCoefficientModel>>(EntityList);
        }

        Task<RiskCoefficientModel> IRepository<RiskCoefficientModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<RiskCoefficientModel>.Update(RiskCoefficientModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
