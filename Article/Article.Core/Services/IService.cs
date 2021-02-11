using Article.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<IDataResult<IEnumerable<T>>> GetAllAsync();
        IDataResult<T> GetById(object id);
        IResult Insert(T entity);
        Task<IResult> InsertAsync(T entity);
        IResult Insert(IEnumerable<T> entities);
        Task<IResult> InsertAsync(IEnumerable<T> entities);
        IResult Update(T entity);
        IResult Update(IEnumerable<T> entities);
        IResult Delete(object id);
        IResult Delete(T entity);
        IResult Delete(IEnumerable<T> entities);
    }
}
