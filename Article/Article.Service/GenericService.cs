using Article.Core.Repositories;
using Article.Core.Services;
using Article.Core.Utilities.Results;
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

        public async Task<IDataResult<IEnumerable<T>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            if (data == null) return new ErrorDataResult<IEnumerable<T>>(null, Messages.ItemNotFound);

            return new SuccessDataResult<IEnumerable<T>>(data, Messages.ItemListed);
        }

        public IDataResult<T> GetById(object id)
        {
            var data = _repository.GetById(id);
            if(data == null) return new ErrorDataResult<T>(null,Messages.ItemNotFound);

            return new SuccessDataResult<T>(_repository.GetById(id),Messages.ItemListed);
        }

        public IResult Insert(T entity)
        {
            _repository.Insert(entity);

            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Insert(IEnumerable<T> entities)
        {
            _repository.Insert(entities);

            return new SuccessResult(Messages.ItemAdded);
        }

        public async Task<IResult> InsertAsync(T entity)
        {
            await _repository.InsertAsync(entity);

            return new SuccessResult(Messages.ItemAdded);
        }

        public async Task<IResult> InsertAsync(IEnumerable<T> entities)
        {
            await _repository.InsertAsync(entities);

            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Update(T entity)
        {
            _repository.Update(entity);

            return new SuccessResult(Messages.ItemUpdated);
        }

        public IResult Update(IEnumerable<T> entities)
        {
            _repository.Update(entities);

            return new SuccessResult(Messages.ItemUpdated);
        }

        public IResult Delete(T entity)
        {
            _repository.Delete(entity);

            return new SuccessResult(Messages.ItemDeleted);
        }

        public IResult Delete(IEnumerable<T> entities)
        {
            _repository.Delete(entities);

            return new SuccessResult(Messages.ItemDeleted);
        }

        public IResult Delete(object id)
        {
            _repository.Delete(id);

            return new SuccessResult(Messages.ItemDeleted);
        }

    }
}
