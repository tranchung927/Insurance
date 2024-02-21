using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Data.Users;
using Server.Data.ClientSupport;
using Server.Data.LifeInsurance;
using Server.Data.VehicleInsurance;

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
        public DbSet<VehicleTypeEntity>? VehicleType { get; set; }
        public DbSet<VehiclePropertyEntity>? VehicleProperty { get; set; }
        public DbSet<InformationEntity>? Information { get; set; }
        public DbSet<InsuranceTypeEntity>? InsuranceType { get; set; }
        public DbSet<DeathRateEntity>? DeathRate { get; set; }
        public DbSet<WorkplaceEntity>? Workplace { get; set; }

        #endregion

    }
}
