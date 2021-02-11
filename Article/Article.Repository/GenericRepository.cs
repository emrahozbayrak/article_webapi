using Article.Core.Repositories;
using Article.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ArticleDBContext _context;
        private DbSet<T> _entities;

        public GenericRepository(ArticleDBContext Context)
        {
            _context = Context;
            _entities = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public virtual T GetById(object id)
        {
            return Entities.Find(id);
        }

        public async virtual Task<T> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Entry(entity).Property("CreatedDate").CurrentValue = DateTime.Now;

            Entities.Add(entity);
            _context.SaveChanges();
        }
        public async Task InsertAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Entry(entity).Property("CreatedDate").CurrentValue = DateTime.Now;

            await Entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task InsertAsync(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
            {
                _context.Entry(entity).Property("CreatedDate").CurrentValue = DateTime.Now;
                await Entities.AddAsync(entity);
            }

            await _context.SaveChangesAsync();
        }

        public virtual void Insert(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
            {
                _context.Entry(entity).Property("CreatedDate").CurrentValue = DateTime.Now;
                Entities.Add(entity);
            }

            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Entry(entity).Property("UpdatedDate").CurrentValue = DateTime.Now;

            Entities.Update(entity);
            _context.SaveChanges();
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
                _context.Entry(entity).Property("UpdatedDate").CurrentValue = DateTime.Now;


            Entities.UpdateRange(entities);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));


            Entities.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
                Entities.Remove(entity);

            _context.SaveChanges();
        }
        public void Delete(object id)
        {
            var data = Entities.Find(id);
            if (data == null)
                throw new ArgumentNullException(nameof(id));

            Entities.Remove(data);
            _context.SaveChanges();
        }

        protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}
