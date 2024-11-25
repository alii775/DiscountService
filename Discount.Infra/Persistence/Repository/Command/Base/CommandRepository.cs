using Discount.Domain.Entities;
using Discount.Domain.IRepository.ICommand;
using Discount.Infra.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infra.Persistence.Repository.Command.Base
{


    public class CommandRepository : ICommandRepository
    {
        protected readonly DiscountCommandDbContext _context;

        public CommandRepository(DiscountCommandDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Coupon coupon)
        {

            try
            {
                _context.Discounts.Add(coupon);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task UpdateAsync(Coupon coupon)
        {
            _context.Discounts.Remove(coupon);
            await _context.SaveChangesAsync();
        }



        public async Task DeleteAsync(long id)
        {
            var coupon = await _context.Discounts.FindAsync(id);
            if (coupon != null)
            {
                _context.Discounts.Remove(coupon);
                await _context.SaveChangesAsync();
            }
        }
    }

}
