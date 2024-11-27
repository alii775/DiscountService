using Discount.Domain.Entities;
using Discount.Domain.IRepository.ICommand;
using Discount.Domain.IRepository.ICommand.Base;
using Discount.Infra.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infra.Persistence.Repository.Command.Base
{


    public class CommandRepository<T> : ICommandRepository<T> where T:class
    {
        protected readonly DiscountCommandDbContext _context;

        public CommandRepository(DiscountCommandDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {

            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

      
    }

}
