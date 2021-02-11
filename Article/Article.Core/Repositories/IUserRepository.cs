using Article.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Core.Repositories
{
    public interface IUserRepository : IRepository<Article.Core.Entities.User>
    {
        Task<Article.Core.Entities.User> LoginAsync(AuthenticateRequest model);

        bool UserNameExist(string username);
    }
}
