using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Core.Repositories
{
    public interface IArticleRepository : IRepository<Article.Core.Entities.Article>
    {
        IEnumerable<Article.Core.Entities.Article> GetWithComments();
        Article.Core.Entities.Article GetWithCommentsById(long id);
        Task<IEnumerable<Article.Core.Entities.Article>> GetByTitleAsync(string keyword);
        Task<IEnumerable<Article.Core.Entities.Article>> GetByAuthorNameAsync(string authorName);

    }
}
