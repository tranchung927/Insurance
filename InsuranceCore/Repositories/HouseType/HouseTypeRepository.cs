using System;
using InsuranceCore.DataContext;

namespace InsuranceCore.Repositories.HouseType
{
	public class HouseTypeRepository: Repository<Data.HouseType>, IHouseTypeRepository
    {
		public HouseTypeRepository(InsuranceDbContext context) : base(context)
		{
		}
	}
}

