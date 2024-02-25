using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server.DataContext
{
    public class PostgreSqlDbContext : InsuranceDbContext
    {
        /// <summary>
        /// context used for PostgreSQL database (compatibility)
        /// </summary>
        public PostgreSqlDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().Property(b => b.RegisteredAt).HasDefaultValueSql("NOW()");
            builder.Entity<User>().Property(b => b.LastLogin).HasDefaultValueSql("NOW()");
            builder.Entity<Post>().Property(b => b.PublishedAt).HasDefaultValueSql("NOW()");
        }
    }
}
