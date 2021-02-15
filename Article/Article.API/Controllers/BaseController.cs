using Article.Core.Services;
using Article.Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TT> : ControllerBase
        where T : class
    {
        private readonly IService<T> _service;
        private readonly ILogger<TT> _logger;
        private readonly IMemoryCache _memoryCache;
        public BaseController(IService<T> service, ILogger<TT> logger, IMemoryCache memoryCache)
        {
            _service = service;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            string key = typeof(T).Name;

            if (_memoryCache.TryGetValue(key, out object list))
            {
                _logger.LogInformation($"{nameof(Article)} List from cache is success");
                return Ok((IDataResult<IEnumerable<T>>)list);
            }


            var result = await _service.GetAllAsync();
            _memoryCache.Set(key, result, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                Priority = CacheItemPriority.Normal
            });

            if (result.Success)
            {
                _logger.LogInformation($"{typeof(T).Name} List is success");
                return Ok(result);
            }

            _logger.LogInformation($"{typeof(T).Name} List is failed");
            return BadRequest(result.Message);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var result = _service.GetById(id);
            _logger.LogInformation($"{typeof(T).Name} List is success");

            if (result.Success)
                return Ok(result);

            _logger.LogInformation($"{typeof(T).Name} List is failed");
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(T model)
        {
            var result = await _service.InsertAsync(model);
            if (result.Success)
            {
                _logger.LogInformation($"{typeof(T).Name} Save is success");
                RemoveCache(typeof(T).Name);
                return Ok(result);
            }


            _logger.LogInformation($"{typeof(T).Name} Save is failed");
            return BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult Put(T model)
        {
            var result = _service.Update(model);
            if (result.Success)
            {
                _logger.LogInformation($"{typeof(T).Name} Update is success");
                RemoveCache(typeof(T).Name);
                return Ok(result);
            }


            _logger.LogInformation($"{typeof(T).Name} Update is failed");
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var result = _service.Delete(id);
            if (result.Success)
            {
                _logger.LogInformation($"{typeof(T).Name} Delete is success");
                RemoveCache(typeof(T).Name);
                return Ok(result);
            }

            _logger.LogInformation($"{typeof(T).Name} Delete is failed");
            return BadRequest(result.Message);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public void RemoveCache(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
