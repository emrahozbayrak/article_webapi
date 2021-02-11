using Article.Core.Repositories;
using Article.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Repository
{
    public class CommentRepository : GenericRepository<Article.Core.Entities.Comment>, ICommentRepository
    {
        private readonly ArticleDBContext _context;
        public CommentRepository(ArticleDBContext Context)
            :base(Context)
        {
            _context = Context;
        }
    }
}
