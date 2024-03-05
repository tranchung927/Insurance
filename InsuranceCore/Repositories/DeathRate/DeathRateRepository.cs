using System;
using InsuranceCore.DataContext;

namespace InsuranceCore.Repositories.DeathRate
{
	public class DeathRateRepository: Repository<Data.DeathRate>, IDeathRateRepository
    {
		public DeathRateRepository(InsuranceDbContext context) : base(context)
        {
        }
    }
}

