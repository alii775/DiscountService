using Discount.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Commands
{
    public record DeleteDiscountCommand : IRequest
    {
        public long CouponId { get; set; }
    }
}

