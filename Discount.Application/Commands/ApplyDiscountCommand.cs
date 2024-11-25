﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Commands
{
    public record ApplyDiscountCommand:IRequest<decimal>
    {
        public long CouponId { get; set; } 
        public decimal OriginalPrice { get; set; } 
    }
  
}
