using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Commands
{
    public class DeleteDiscountCommand : IRequest
    {
        public long couponId { get; set; }
    }
}

