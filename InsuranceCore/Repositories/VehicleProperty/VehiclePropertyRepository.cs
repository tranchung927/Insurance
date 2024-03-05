using System;
using InsuranceCore.DataContext;

namespace InsuranceCore.Repositories.VehicleProperty
{
    public class VehiclePropertyRepository : Repository<Data.VehicleProperty>, IVehiclePropertyRepository
    {
        public VehiclePropertyRepository(InsuranceDbContext context) : base(context)
        {
        }
    }
}

