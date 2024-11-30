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
    public class DiscountCommandDbContext : DbContext
    {
        private readonly IConfiguration _cofiguration;

        public DiscountCommandDbContext(IConfiguration cofiguration)
        {
            _cofiguration = cofiguration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_cofiguration.GetConnectionString("CommandConnection"));

        }
        public DbSet<Coupon> Discounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>()
                .Property(c => c.DiscountType)

                .HasConversion<int>();
            modelBuilder.Entity<Coupon>()
                 .Property(c => c.Id)

                 .ValueGeneratedOnAdd();

        }
    }
}
