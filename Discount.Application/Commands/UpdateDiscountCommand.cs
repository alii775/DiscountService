using Discount.Application.Services;
using Discount.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Commands
{

    public record UpdateDiscountCommand : IRequest
    {
        public long Id { get; set; }
        [Range(1,2)]
        public DiscountType DiscountType { get; set; }
        [PercentageRange]
        public decimal DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}
