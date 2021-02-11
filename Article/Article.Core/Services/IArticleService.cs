using Article.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Core.Services
{
    public interface IArticleService : IService<Article.Core.Entities.Article>
    {
        IDataResult<IEnumerable<Article.Core.Entities.Article>> GetWithComments();
        IDataResult<Article.Core.Entities.Article> GetWithCommentsById(long id);
        Task<IDataResult<IEnumerable<Article.Core.Entities.Article>>> GetByTitleAsync(string keyword);
        Task<IDataResult<IEnumerable<Article.Core.Entities.Article>>> GetByAuthorNameAsync(string authorName);
    }
}
