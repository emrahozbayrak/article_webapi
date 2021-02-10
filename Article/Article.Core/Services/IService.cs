using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Core.Services
{
    public interface IService<T> where T : class
    {
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
        T GetById(object id);
        void Insert(T entity);
        Task InsertAsync(T entity);
        void Insert(IEnumerable<T> entities);
        Task InsertAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        IEnumerable<T> GetSql(string sql);
    }
}
