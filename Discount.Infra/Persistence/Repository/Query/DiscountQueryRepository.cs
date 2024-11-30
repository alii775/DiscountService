using Discount.Domain.Entities;
using Discount.Domain.IRepository.IQuery;
using Discount.Infra.Persistence.Data;
using Discount.Infra.Persistence.Repository.Query.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infra.Persistence.Repository.Query
{
    public class DiscountQueryRepository : QueryRepository<Coupon>, IDiscountQueryRepository
    {
        private readonly DiscountQueryDbContext _context;

        public DiscountQueryRepository(DiscountQueryDbContext context):base(context) 
        {
            _context = context;
        }

        public async Task<List<Coupon>> GetActiveDiscountAsync(DateTime currentDate)
        {

            var res = await _context.Discounts
              .Where(d => d.StartDate <= currentDate && d.EndDate >= currentDate)
              .ToListAsync();
            return res;


        }


        public async Task<Coupon> GetByIdAsync(long  id)
        {
          var res = await _context.Discounts.FirstOrDefaultAsync(u =>u.Id==id);
            return res;
        }

      
    }
}
