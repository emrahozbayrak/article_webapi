using Article.Core.Services;
using Article.Core.Utilities.Results;
using Article.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : BaseController<Article.Core.Entities.Article>
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService) : base(articleService)
        {
            _articleService = articleService;
        }

        // Searching with Article Title
        [HttpGet("getbytitle/{keyword}")]
        public async Task<IDataResult<IEnumerable<Article.Core.Entities.Article>>> GetAllByTitleAsync(string keyword)
        {
            return await _articleService.GetByTitleAsync(keyword);
        }

        // Searching with Author Name
        [HttpGet("getbyauthor/{authorName}")]
        public async Task<IDataResult<IEnumerable<Article.Core.Entities.Article>>> GetByAuthorAsync(string authorName)
        {
            return await _articleService.GetByTitleAsync(authorName);
        }
    }
}
