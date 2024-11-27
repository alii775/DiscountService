﻿using Discount.Domain.Entities;
using Discount.Domain.IRepository.ICommand.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.IRepository.ICommand
{
    public interface IDiscountCommandRepository:ICommandRepository<Coupon>
    {
       

    }
}