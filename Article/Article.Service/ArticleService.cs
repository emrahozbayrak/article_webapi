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
    public class ArticleService : GenericService<Article.Core.Entities.Article>, IArticleService
    {
        private readonly ArticleDBContext _context;
        private readonly IArticleRepository _articleRepo;

        public ArticleService(ArticleDBContext Context, IArticleRepository ArticleRepository)
            :base(Context,ArticleRepository)
        {
            _context = Context;
            _articleRepo = ArticleRepository;
        }

        public async Task<IEnumerable<Core.Entities.Article>> GetByAuthorNameAsync(string authorName)
        {
            return await _articleRepo.GetByAuthorNameAsync(authorName);
        }

        public async Task<IEnumerable<Core.Entities.Article>> GetByTitleAsync(string keyword)
        {
            return await _articleRepo.GetByTitleAsync(keyword);
        }
    }
}
