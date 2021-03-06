﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(object id);
        void Insert(T entity);
        Task InsertAsync(T entity);
        void Insert(IEnumerable<T> entities);
        Task InsertAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(object id);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
    }
}
