using Discount.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.Entities
{
    public class Coupon
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive => DateTime.Now >= StartDate && DateTime.Now <= EndDate;
      
    }
}
