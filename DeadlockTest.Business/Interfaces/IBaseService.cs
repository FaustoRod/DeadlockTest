using DeadlockTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeadlockTest.Business.Interfaces
{
    public interface IBaseService<T> where T: BaseModel
    {
        Task<bool> Create(T entity);
        Task<T> GetById(int id);
        Task<T> GetBySingle(Expression<Func<T, bool>> expression);
        Task<TViewModel> GetBySingle<TViewModel>(Expression<Func<T, bool>> expression);
        Task<bool> Create<TViewModel>(TViewModel entity);
        Task<bool> Edit<TViewModel>(TViewModel entity);
        Task<IList<T>> GetList();
        Task<IList<T>> GetList(Expression<Func<T, bool>> expression);
        Task<IList<TViewModel>> GetList<TViewModel>();
        Task<IList<TViewModel>> GetList<TViewModel>(Expression<Func<T, bool>> expression);
        Task<bool> Edit(T entity);
    }
}
