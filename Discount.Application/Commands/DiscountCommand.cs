using Discount.Application.Services;
using Discount.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Discount.Application.Commands;

public record DiscountCommand:IRequest<bool>
{
    [JsonIgnore]
    public int TypeRequst { get; set; }
    public long CategoryId { get; set; }
    [Range(1, 2)]
    public DiscountType DiscountType { get; set; }
    [PercentageRange]
    public decimal DiscountValue { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
