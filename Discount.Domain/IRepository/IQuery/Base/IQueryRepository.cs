using Discount.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.IRepository.IQuery.Base
{
    public interface IQueryRepository<T> where T : class
    {
       Task<List<T>> GetAll();
    }
}

