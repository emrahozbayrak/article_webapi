using Article.Core.Repositories;
using Article.Core.Services;
using Article.Core.Utilities.Results;
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
            : base(Context, ArticleRepository)
        {
            _context = Context;
            _articleRepo = ArticleRepository;
        }

        public async Task<IDataResult<IEnumerable<Core.Entities.Article>>> GetByAuthorNameAsync(string authorName)
        {
            return new SuccessDataResult<IEnumerable<Core.Entities.Article>>(await _articleRepo.GetByAuthorNameAsync(authorName));
        }

        public async Task<IDataResult<IEnumerable<Core.Entities.Article>>> GetByTitleAsync(string keyword)
        {
            return new SuccessDataResult<IEnumerable<Core.Entities.Article>>(await _articleRepo.GetByTitleAsync(keyword));
        }

        public IDataResult<IEnumerable<Core.Entities.Article>> GetWithComments()
        {
            return new SuccessDataResult<IEnumerable<Core.Entities.Article>>(_articleRepo.GetWithComments());
        }

        public IDataResult<Core.Entities.Article> GetWithCommentsById(long id)
        {
            return new SuccessDataResult<Core.Entities.Article>(_articleRepo.GetWithCommentsById(id));
        }

    }
}
