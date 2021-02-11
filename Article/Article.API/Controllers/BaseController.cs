using Article.Core.Services;
using Article.Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
        where T : class
    {
        private readonly IService<T> _service;

        public BaseController(IService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IDataResult<IEnumerable<T>>> GetAllAsync()
        {
            return await _service.GetAllAsync();
        }


        [HttpGet("{id}")]
        public IDataResult<T> GetById(long id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public async Task<IResult> PostAsync(T model)
        {
            return await _service.InsertAsync(model);
        }

        [HttpPut]
        public IResult Put(T model)
        {
            return _service.Update(model);
        }

        [HttpDelete("{id}")]
        public IResult Delete(long id)
        {
            return _service.Delete(id);
        }
    }
}
