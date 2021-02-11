using Article.Core.Services;
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
    public class CommentsController : BaseController<Article.Core.Entities.Comment>
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService) : base(commentService)
        {
            _commentService = commentService;
        }
    }
}
