using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discount.Domain.Enums;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
namespace Discount.Application.Command
{
    public record CreateDiscountCommand : IRequest<long>
    {
        public long CategoryId { get; set; }
        [Range(1, 2)]
        public DiscountType DiscountType { get; set; }
        [Range(0, 100)]
        public decimal DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


}
