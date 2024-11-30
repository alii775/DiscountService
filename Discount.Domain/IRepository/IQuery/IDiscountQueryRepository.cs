using Discount.Domain.Entities;
using Discount.Domain.IRepository.IQuery.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.IRepository.IQuery
{
    public interface IDiscountQueryRepository:IQueryRepository<Coupon>
    {
        Task<Coupon> GetByIdAsync(long id);

        Task<List<Coupon>> GetActiveDiscountAsync(DateTime dateTime);
    }
}
