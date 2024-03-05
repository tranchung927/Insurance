using System;
using InsuranceCore.DataContext;

namespace InsuranceCore.Repositories.HouseSize
{
	public class HouseSizeRepository: Repository<Data.HouseSize>, IHouseSizeRepository
	{
		public HouseSizeRepository(InsuranceDbContext context) : base(context)
		{
		}
	}
}

