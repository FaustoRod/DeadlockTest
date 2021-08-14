using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeadlockTest.Business.Interfaces
{
    public interface IBaseService<T> where T: class
    {
        Task<bool> Create(T entity);
        Task<bool> Create<TViewModel>(TViewModel entity);
        Task<IList<T>> GetList();
        Task<bool> Edit(T entity);
    }
    public interface IBaseService<T,TViewModel> where T: class
        where TViewModel : class
    {
        Task<bool> Create(T entity);
        Task<bool> Create(TViewModel entity);
        Task<IList<T>> GetList();
        Task<IList<T>> GetList(Expression<Func<T, bool>> expression);
        Task<bool> Edit(T entity);
        Task<bool> Edit(TViewModel entity);
    }
}
