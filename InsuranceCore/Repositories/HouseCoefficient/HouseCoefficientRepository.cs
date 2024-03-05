using System;
using InsuranceCore.DataContext;

namespace InsuranceCore.Repositories.HouseCoefficient
{
	public class HouseCoefficientRepository: Repository<Data.HouseCoefficient>, IHouseCoefficientRepository
	{
		public HouseCoefficientRepository(InsuranceDbContext context) : base(context)
        {
        }
    }
}

