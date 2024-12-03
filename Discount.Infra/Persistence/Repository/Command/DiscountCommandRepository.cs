using Discount.Domain.Entities;
using Discount.Domain.IRepository.ICommand;
using Discount.Infra.Persistence.Data;
using Discount.Infra.Persistence.Repository.Command.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infra.Persistence.Repository.Command
{
    public class DiscountCommandRepository : CommandRepository<Coupon>,IDiscountCommandRepository
    {
        private readonly DiscountCommandDbContext _context;

        public DiscountCommandRepository(DiscountCommandDbContext context):base(context)
        {
            _context = context;
        }
       




    }
}
















    