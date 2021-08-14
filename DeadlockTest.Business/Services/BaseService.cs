using AutoMapper;
using DeadlockTest.Business.Interfaces;
using DeadlockTest.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeadlockTest.Business.Services
{
    public abstract class BaseService<T, TContext> : IBaseService<T> where T : BaseModel
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly IMapper _mapper;

        public BaseService(TContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<bool> Create(T entity)
        {
            var dbSet = _context.Set<T>();
            entity.CreationDate = DateTime.Now;
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

        public async virtual Task<bool> Create<TViewModel>(TViewModel entity)
        {
            try
            {
                var model = _mapper.Map<T>(entity);
                return await Create(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual async Task<bool> Edit(T entity)
        {
            var dbSet = _context.Set<T>();
            entity.ModificationDate = DateTime.Now;
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

        public async Task<bool> Edit<TViewModel>(TViewModel entity)
        {
            try
            {
                var model = _mapper.Map<TViewModel, T>(entity);
                return await Edit(model);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<T> GetById(int id)
        {
            var dbSet = _context.Set<T>();
            return await dbSet.FindAsync(id);
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

        public async Task<IList<TViewModel>> GetList<TViewModel>()
        {
            var list = await GetList();
            try
            {
                var mappedList = _mapper.Map<IList<TViewModel>>(list);
                return mappedList;
            }
            catch (Exception)
            {

                return new List<TViewModel>();
            }
        }

        public async Task<IList<TViewModel>> GetList<TViewModel>(Expression<Func<T, bool>> expression)
        {
            var list = await GetList(expression);
            try
            {
                var mappedList = _mapper.Map<IList<TViewModel>>(list);
                return mappedList;
            }
            catch (Exception)
            {

                return new List<TViewModel>();
            }
        }
    }

}
