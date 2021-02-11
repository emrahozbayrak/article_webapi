using Article.Core.Repositories;
using Article.Core.Services;
using Article.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service
{
    public class CommentService : GenericService<Article.Core.Entities.Comment>, ICommentService
    {
        private readonly ArticleDBContext _context;
        private readonly ICommentRepository _commentRepo;
        public CommentService(ArticleDBContext context,ICommentRepository commentRepo)
            :base(context,commentRepo)
        {
            _context = context;
            _commentRepo = commentRepo;
        }
    }
}
