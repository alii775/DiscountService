using Discount.Domain.Entities;
using Discount.Domain.IRepository.IQuery.Base;
using Discount.Infra.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infra.Persistence.Repository.Query
{
    public class QueryRepository : IQueryRepository
    {
        private readonly DiscountQueryDbContext _context;

        public QueryRepository(DiscountQueryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Coupon>> GetActiveDiscountAsync()
        {

            var now = DateTime.Now;
            return await _context.Discounts
                .Where(c => c.StartDate <= now && c.EndDate >= now)
                .ToListAsync();
        }

        public async Task<Coupon> GetByIdAsync(long id)
        {
            var res = await _context.Discounts.FirstOrDefaultAsync(d => d.Id == id);

            return res;

        }



    }
}
