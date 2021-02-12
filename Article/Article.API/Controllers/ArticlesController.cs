using Article.Core.Services;
using Article.Core.Utilities.Results;
using Article.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public ArticlesController(IArticleService articleService, ILogger<ArticlesController> logger) : base(articleService, logger)
        {
            _articleService = articleService;
            _logger = logger;
        }

        // Searching with Article Title
        [HttpGet("getbytitle/{keyword}")]
        public async Task<IDataResult<IEnumerable<Article.Core.Entities.Article>>> GetAllByTitleAsync(string keyword)
        {
            var result = await _articleService.GetByTitleAsync(keyword);
            _logger.LogInformation($"{nameof(Article)} Search by Title is success");

            return result;
        }

        // Searching with Author Name
        [HttpGet("getbyauthor/{authorName}")]
        public async Task<IDataResult<IEnumerable<Article.Core.Entities.Article>>> GetByAuthorAsync(string authorName)
        {
            var result = await _articleService.GetByTitleAsync(authorName);
            _logger.LogInformation($"{nameof(Article)} Search by AuthorName is success");

            return result;
        }

        // Get Data with Comments
        [HttpGet("getwithcomments")]
        public IDataResult<IEnumerable<Article.Core.Entities.Article>> GetWithComments()
        {
            var result = _articleService.GetWithComments();
            _logger.LogInformation($"{nameof(Article)} List with Comments is success");

            return result;
        }

        // Get Data By Id with Comments
        [HttpGet("getwithcomments/{id}")]
        public IDataResult<Article.Core.Entities.Article> GetWithCommentsById(long id)
        {
            var result = _articleService.GetWithCommentsById(id);
            _logger.LogInformation($"{nameof(Article)} Search with Comments is success");

            return result;
        }
    }
}
