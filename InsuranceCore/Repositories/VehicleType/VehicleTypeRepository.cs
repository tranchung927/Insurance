using System;
using InsuranceCore.DataContext;

namespace InsuranceCore.Repositories.VehicleType
{
	public class VehicleTypeRepository: Repository<Data.VehicleType>, IVehicleTypeRepository
	{
		public VehicleTypeRepository(InsuranceDbContext context) : base(context)
		{
		}
	}
}

