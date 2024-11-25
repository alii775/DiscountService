using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.DTOs
{
    public class CouponDto
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        [Range(1,2)]
        public string DiscountType { get; set; }
       
        public decimal DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } 
    }

}
