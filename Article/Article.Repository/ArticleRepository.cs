using Article.Core.Repositories;
using Article.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Repository
{
    public class ArticleRepository : GenericRepository<Article.Core.Entities.Article>, IArticleRepository
    {
        private readonly ArticleDBContext _context;
        public ArticleRepository(ArticleDBContext Context)
            :base(Context)
        {
            _context = Context;
        }

        public async Task<IEnumerable<Core.Entities.Article>> GetByAuthorNameAsync(string authorName)
        {
            return await _context.Articles.Where(p =>  p.AuthorName.Contains(authorName)).ToListAsync();
        }

        public async Task<IEnumerable<Core.Entities.Article>> GetByTitleAsync(string keyword)
        {
            return await _context.Articles.Where(p => p.ArticleTitle.Contains(keyword)).ToListAsync();
        }
    }
}
