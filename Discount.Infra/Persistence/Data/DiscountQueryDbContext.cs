using Discount.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infra.Persistence.Data
{
    public class DiscountQueryDbContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public DiscountQueryDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("QueryConnection"));
        }
        public DbSet<Coupon> Discounts { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>()
                .Property(c => c.DiscountType)
                .HasConversion<int>();
        }
    }
}
