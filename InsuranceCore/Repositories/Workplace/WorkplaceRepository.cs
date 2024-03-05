using System;
using InsuranceCore.DataContext;

namespace InsuranceCore.Repositories.Workplace
{
	public class WorkplaceRepository : Repository<Data.Workplace>, IWorkplaceRepository
    {
        public WorkplaceRepository(InsuranceDbContext context) : base(context)
        {
        }
    }
}

