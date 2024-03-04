using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InsuranceCore.Data;
using InsuranceCore.Data.JoiningEntity;
using System.Reflection.Emit;

namespace InsuranceCore.DataContext
{
    public class InsuranceDbContext: IdentityDbContext<
        User,
        Role, int,
        IdentityUserClaim<int>,
        UserRole,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>
        >
    {
        protected InsuranceDbContext(DbContextOptions options) : base(options) { }

        #region DbSet Section
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetails> OrderDetails { get; set; }

        #endregion
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<DefaultRoles> DefaultRoles { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Policy> Policies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Identity");

            builder.Entity<PostTag>()
               .HasKey(pt => new { pt.PostId, pt.TagId });

            builder.Entity<UserRole>(entity =>
            {
                entity
                    .HasOne(x => x.Role)
                    .WithMany(x => x.UserRoles)
                    .HasForeignKey(x => x.RoleId);

                entity
                    .HasOne(x => x.User)
                    .WithMany(x => x.UserRoles)
                    .HasForeignKey(x => x.UserId);
            });

            builder.Entity<Post>().HasOne(e => e.Category).WithMany(e => e.Posts).IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Post>().HasOne(e => e.Author).WithMany(e => e.Posts).IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.Entity<DefaultRoles>().HasOne(e => e.Role).WithMany(e => e.DefaultRoles).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<District>().HasOne(e => e.City).WithMany(e => e.Districts).IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Address>(entity =>
            {
                entity
                    .HasOne(e => e.City)
                    .WithMany(e => e.Addresses)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);

                entity
                     .HasOne(e => e.District)
                     .WithMany(e => e.Addresses)
                     .IsRequired()
                     .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "Users");
            });
            builder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
            builder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }

    }
}
