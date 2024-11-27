
using Discount.Domain.Entities;
using Discount.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Services
{
    public class CalculateService
    {
      

      

        public decimal CalculateDiscount(decimal originalPrice, Coupon coupon)
        {
            if (!coupon.IsActive)
            {
                throw new InvalidOperationException("Coupon is not active.");
            }

            return coupon.DiscountType switch
            {
                DiscountType.Percent => originalPrice * (coupon.DiscountValue / 100),
                DiscountType.Amount => coupon.DiscountValue,
                _ => throw new NotSupportedException("Unsupported discount type.")
            };
        }
    }

}
