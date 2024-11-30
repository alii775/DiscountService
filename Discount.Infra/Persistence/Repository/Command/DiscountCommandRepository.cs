using Discount.Domain.Entities;
using Discount.Domain.IRepository.ICommand;
using Discount.Infra.Persistence.Data;
using Discount.Infra.Persistence.Repository.Command.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infra.Persistence.Repository.Command
{
    public class DiscountCommandRepository : CommandRepository<Coupon>, IDiscountCommandRepository
    {
        private readonly DiscountCommandDbContext _context;

        public DiscountCommandRepository(DiscountCommandDbContext context):base(context)
        {
            _context = context;
        }
        public async Task DeleteAsync(Coupon coupon)
        {
            var res= await _context.Discounts.FindAsync(coupon.Id);
            if (res != null)
            {
                _context.Discounts.Remove(res);
                await _context.SaveChangesAsync();

            }
            else 
            {
                throw new Exception("Id Not Found");
    
            }
        }
















    }
}
