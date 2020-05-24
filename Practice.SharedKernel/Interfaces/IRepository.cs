using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practice.SharedKernel.Interfaces
{
    public interface IRepository
    {
        T GetSingle<T>(Expression<Func<T, bool>> condition) where T : class;

        List<T> GetAll<T>() where T : class;

        List<T> Get<T>(Expression<Func<T, bool>> condition) where T : class;

        T Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;


        Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> condition) where T : class;

        Task<List<T>> GetAllAsync<T>() where T : class;

        Task<List<T>> GetAsync<T>(Expression<Func<T, bool>> condition) where T : class;
    }
}
