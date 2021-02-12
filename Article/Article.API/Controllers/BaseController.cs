using Article.Core.Services;
using Article.Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T,TT> : ControllerBase
        where T : class
    {
        private readonly IService<T> _service;
        private readonly ILogger<TT> _logger;

        public BaseController(IService<T> service, ILogger<TT> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IDataResult<IEnumerable<T>>> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            _logger.LogInformation($"{typeof(T).Name} List is success");

            return result;
        }


        [HttpGet("{id}")]
        public IDataResult<T> GetById(long id)
        {
            var result = _service.GetById(id);
            _logger.LogInformation($"{typeof(T).Name} List is success");

            return result;
        }

        [HttpPost]
        public async Task<IResult> PostAsync(T model)
        {
            var result = await _service.InsertAsync(model);
            _logger.LogInformation($"{typeof(T).Name} Save is success");
            return result;
        }

        [HttpPut]
        public IResult Put(T model)
        {
            var result =  _service.Update(model);
            _logger.LogInformation($"{typeof(T).Name} Update is success");

            return result;
        }

        [HttpDelete("{id}")]
        public IResult Delete(long id)
        {
            var result = _service.Delete(id);
            _logger.LogInformation($"{typeof(T).Name} Delete is success");

            return result;
        }
    }
}
