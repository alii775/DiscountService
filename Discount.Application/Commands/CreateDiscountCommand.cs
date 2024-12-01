using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discount.Domain.Enums;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using Discount.Application.Services;
namespace Discount.Application.Commands
{


    public class CreateDiscountCommand : IRequest
    {
        [Range(1, 2)]
        public DiscountType DiscountType { get; set; }
        public decimal Amount { get; set; }
        [PercentageRange]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
