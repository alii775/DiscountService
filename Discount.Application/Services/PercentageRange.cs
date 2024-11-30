using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Discount.Domain.Enums;
namespace Discount.Application.Services
{


  

    public class PercentageRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           
            var discountTypeProperty = validationContext.ObjectType.GetProperty("DiscountType");
            if (discountTypeProperty != null)
            {
                var discountTypeValue = discountTypeProperty.GetValue(validationContext.ObjectInstance);

           
                if (discountTypeValue != null && discountTypeValue.Equals(DiscountType.Percent))
                {
                
                    if (value is decimal discountValue)
                    {
                        if (discountValue < 0 || discountValue > 100)
                        {
                            return new ValidationResult("For percentage discounts, the value must be between 0 and 100.", new[] { validationContext.MemberName });
                        }
                    }
                    else
                    {
                        return new ValidationResult("Invalid discount value.");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }

}
