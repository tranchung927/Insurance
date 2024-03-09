using System;
using InsuranceCore.DataContext;

namespace InsuranceCore.Repositories.HouseRiskCoefficient
{
    public class HouseRiskCoefficientRepository : Repository<Data.HouseRiskCoefficient>, IHouseRiskCoefficientRepository
    {
        public HouseRiskCoefficientRepository(InsuranceDbContext context) : base(context)
        {
        }
    }
}