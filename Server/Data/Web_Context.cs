using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Data.Users;
using Server.Data.ClientSupport;
using Server.Data.LifeInsurance;

namespace Server.Data
{
    public class Web_Context : IdentityDbContext<UserEntity>
    {
        public Web_Context(DbContextOptions<Web_Context> otp) : base(otp)
        {

        }
        #region
        public DbSet<UserEntity>? User { get; set; }
        public DbSet<JobsRiskEntity>? JobsRisk { get; set; }
        //public DbSet<VehicleType>? vehicle_type { get; set; }
        //public DbSet<VehicleProperty>? vehicle_property { get; set; }
        public DbSet<InformationEntity>? Information { get; set; }
        public DbSet<InsuranceTypeEntity>? InsuranceType { get; set; }
        public DbSet<DeathRateEntity>? DeathRate { get; set; }
        public DbSet<WorkplaceEntity>? Workplace { get; set; }

        #endregion

    }
}
