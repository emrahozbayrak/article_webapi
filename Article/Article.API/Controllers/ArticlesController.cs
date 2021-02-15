using Article.Core.Services;
using Article.Core.Utilities.Results;
using Article.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : BaseController<Article.Core.Entities.Article, ArticlesController>
    {
        private readonly IArticleService _articleService;
        private readonly ILogger<ArticlesController> _logger;
        private readonly IMemoryCache _memoryCache;


        public ArticlesController(IArticleService articleService, ILogger<ArticlesController> logger,
            IMemoryCache memoryCache) : base(articleService, logger, memoryCache)
        {
            _articleService = articleService;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        // Searching with Article Title
        [HttpGet("getbytitle/{keyword}")]
        public async Task<IActionResult> GetAllByTitleAsync(string keyword)
        {
            var result = await _articleService.GetByTitleAsync(keyword);
            if (result.Success)
            {
                _logger.LogInformation($"{nameof(Article)} Search by Title is success");
                return Ok(result);
            }

            _logger.LogInformation($"{nameof(Article)} Search by Title failed");
            return BadRequest(result.Message);
        }

        // Searching with Author Name
        [HttpGet("getbyauthor/{authorName}")]
        public async Task<IActionResult> GetByAuthorAsync(string authorName)
        {
            var result = await _articleService.GetByTitleAsync(authorName);
            if (result.Success)
            {
                _logger.LogInformation($"{nameof(Article)} Search by AuthorName is success");
                return Ok(result);
            }

            _logger.LogInformation($"{nameof(Article)} Search by AuthorName failed");
            return BadRequest(result.Message);
        }

        // Get Data with Comments
        [HttpGet("getwithcomments")]
        public IActionResult GetWithComments()
        {
            var result = _articleService.GetWithComments();
            if (result.Success)
            {
                _logger.LogInformation($"{nameof(Article)} List with Comments is success");
                return Ok(result);
            }

            _logger.LogInformation($"{nameof(Article)} List with Comments failed");
            return BadRequest(result.Message);
        }

        // Get Data By Id with Comments
        [HttpGet("getwithcomments/{id}")]
        public IActionResult GetWithCommentsById(long id)
        {
            var result = _articleService.GetWithCommentsById(id);
            if (result.Success)
            {
                _logger.LogInformation($"{nameof(Article)} Search with Comments is success");
                return Ok(result);
            }

            _logger.LogInformation($"{nameof(Article)} Search with Comments failed");
            return BadRequest(result.Message);
        }
    }
}
