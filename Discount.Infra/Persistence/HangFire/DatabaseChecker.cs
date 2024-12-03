using Discount.Infra.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infra.Persistence.HangFire
{
    public class DatabaseChecker
    {
        private readonly DiscountCommandDbContext _context;

        public DatabaseChecker(DiscountCommandDbContext context)
        {
            _context = context;
        }
        public void CheckAndUpdateDiscounts()
        {
            var currentDate = DateTime.Now;

          
            foreach (var discount in _context.Discounts)
            {
                discount.IsActive = discount.StartDate <= currentDate && discount.EndDate >= currentDate;
            }

          
            _context.SaveChanges();
        }
    }
}
