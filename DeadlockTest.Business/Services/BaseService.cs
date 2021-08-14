using DeadlockTest.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeadlockTest.Business.Services
{
    public abstract class BaseService<T, TContext> : IBaseService<T> where T : class
        where TContext : DbContext
    {
        private readonly TContext _context;

        public BaseService(TContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> Create(T entity)
        {
            var dbSet = _context.Set<T>();
            
            dbSet.Add(entity);
            try
            {
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual Task<bool> Create<TViewModel>(TViewModel entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Edit(T entity)
        {
            var dbSet = _context.Set<T>();
            dbSet.Add(entity);
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual async Task<IList<T>> GetList()
        {
            var dbSet = _context.Set<T>();
            return await dbSet.ToListAsync();
        }
        public virtual async Task<IList<T>> GetList(Expression<Func<T, bool>> expression)
        {
            var dbSet = _context.Set<T>();
            var result = await dbSet.Where(expression).ToListAsync();
            return result;
        }
    }
}
