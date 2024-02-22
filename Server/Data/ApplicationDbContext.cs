﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region DbSet Section
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetails> OrderDetails { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ApplicationDbContextConfigurations.Configure(builder);
            ApplicationDbContextConfigurations.SeedData(builder);

        }

    }
}
