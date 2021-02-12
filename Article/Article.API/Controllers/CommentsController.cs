using Article.Core.Services;
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
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : BaseController<Article.Core.Entities.Comment, CommentsController>
    {
        private readonly ICommentService _commentService;
        private readonly ILogger<CommentsController> _logger;
        private readonly IMemoryCache _memoryCache;
        public CommentsController(ICommentService commentService, ILogger<CommentsController> logger,
            IMemoryCache memoryCache) : base(commentService,logger,memoryCache)
        {
            _commentService = commentService;
            _logger = logger;
            _memoryCache = memoryCache;
        }
    }
}
