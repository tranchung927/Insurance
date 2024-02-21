using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Data.Users;
using Server.Data.ClientSupport;
using Server.Data.LifeInsurance;
using Server.Data.VehicleInsurance;
using Server.Data.HomeInsurance;

namespace Server.Data
{
    public class Web_Context : IdentityDbContext<UserEntity>
    {
        public Web_Context(DbContextOptions<Web_Context> otp) : base(otp)
        {

        }
        #region
        // người dùng
        public DbSet<UserEntity>? User { get; set; }

        // bảo hiểm nhân thọ
        public DbSet<JobsRiskEntity>? JobsRisk { get; set; }
        public DbSet<DeathRateEntity>? DeathRate { get; set; }
        public DbSet<WorkplaceEntity>? Workplace { get; set; }

        // bảo hiểm xe
        public DbSet<VehicleTypeEntity>? VehicleType { get; set; }
        public DbSet<VehiclePropertyEntity>? VehicleProperty { get; set; }

        // chăm sóc khách hàng
        public DbSet<InformationEntity>? Information { get; set; }
        public DbSet<InsuranceTypeEntity>? InsuranceType { get; set; }

        //  bảo hiểm nhà
        public DbSet<HomeCoefficientEntity>? HomeCoefficient { get; set; }
        public DbSet<HomeTypeEntity>? HomeType { get; set; }
        public DbSet<SizeTypeEntity>? SizeType { get; set; }
        public DbSet<RiskCoefficientEntity>? RiskCoefficient { get; set; }

        #endregion

    }
}
