using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Core.Repositories
{
    public interface IArticleRepository : IRepository<Article.Core.Entities.Article>
    {
        Task<IEnumerable<Article.Core.Entities.Article>> GetByTitle(string keyword);
    }
}
