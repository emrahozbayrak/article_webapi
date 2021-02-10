using Article.Core.Repositories;
using Article.Core.Services;
using Article.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service
{
    public class GenericService<T> : IService<T> where T : class
    {
        private readonly ArticleDBContext _context;
        private readonly IRepository<T> _repository;

        public GenericService(ArticleDBContext Context, IRepository<T> Repository)
        {
            _context = Context;
            _repository = Repository;
        }
        public IQueryable<T> Table => _repository.Table;

        public IQueryable<T> TableNoTracking => _repository.TableNoTracking;

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _context.SaveChanges();
        }

        public void Delete(IEnumerable<T> entities)
        {
            _repository.Delete(entities);
            _context.SaveChanges();
        }

        public T GetById(object id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<T> GetSql(string sql)
        {
            return _repository.GetSql(sql);
        }

        public void Insert(T entity)
        {
            _repository.Insert(entity);
            _context.SaveChanges();
        }

        public void Insert(IEnumerable<T> entities)
        {
            _repository.Insert(entities);
            _context.SaveChanges();
        }

        public async Task InsertAsync(T entity)
        {
            await _repository.InsertAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task InsertAsync(IEnumerable<T> entities)
        {
            await _repository.InsertAsync(entities);
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _context.SaveChanges();
        }

        public void Update(IEnumerable<T> entities)
        {
            _repository.Update(entities);
            _context.SaveChanges();
        }
    }
}
