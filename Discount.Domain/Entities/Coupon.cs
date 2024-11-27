using Discount.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;
namespace Discount.Domain.Entities
{
    public class Coupon:BaseEntity
    {
      
        public long CategoryId { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public  bool IsActive { get; set; }
      
    }
}
