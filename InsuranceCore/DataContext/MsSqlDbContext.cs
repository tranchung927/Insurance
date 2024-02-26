using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using InsuranceCore.Data;

namespace InsuranceCore.DataContext
{
    /// <summary>
    /// context used for Microsoft SQL Server database (compatibility)
    /// </summary>
    public class MsSqlDbContext : InsuranceDbContext
    {
        /// <inheritdoc />
        public MsSqlDbContext(DbContextOptions options) : base(options) { }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().Property(b => b.RegisteredAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");
            builder.Entity<User>().Property(b => b.LastLogin).HasDefaultValueSql("SYSDATETIMEOFFSET()");
            builder.Entity<Post>().Property(b => b.PublishedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");
        }
    }
}
