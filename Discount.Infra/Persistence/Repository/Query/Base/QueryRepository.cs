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

namespace Discount.Infra.Persistence.Repository.Query.Base
{
    public class QueryRepository<T> : IQueryRepository<T> where T:class
    {
        private readonly DiscountQueryDbContext _context;

        public QueryRepository(DiscountQueryDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAll()
        {
            var res =await _context.Set<T>().ToListAsync();
            return res;
        }
    }
}
