using Article.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : BaseController<Article.Core.Entities.Comment,ArticlesController>
    {
        private readonly ICommentService _commentService;
        private readonly ILogger<ArticlesController> _logger;

        public CommentsController(ICommentService commentService, ILogger<ArticlesController> logger) : base(commentService,logger)
        {
            _commentService = commentService;
            _logger = logger;
        }
    }
}
