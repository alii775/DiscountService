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

            var items = _context.Discounts.Where(x => x.StartDate <=DateTime.Now&&x.EndDate>=DateTime.Now).ToList();

            foreach (var item in items)
            {
                item.IsActive = true;
            }


            _context.SaveChanges();


        }
    }
}
