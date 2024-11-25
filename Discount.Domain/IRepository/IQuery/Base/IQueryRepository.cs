using Discount.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.IRepository.IQuery.Base
{
    public interface IQueryRepository
    {
        Task<Coupon> GetByIdAsync(long id);

        Task<List<Coupon>> GetActiveDiscountAsync();
    }
}

