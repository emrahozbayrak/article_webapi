using Article.Core.Entities;
using Article.Core.Models;
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
    public class UserRepository : GenericRepository<Article.Core.Entities.User>, IUserRepository
    {
        private readonly ArticleDBContext _context;
        public UserRepository(ArticleDBContext Context)
            : base(Context)
        {
            _context = Context;
        }

        public async Task<User> LoginAsync(AuthenticateRequest model)
        {
           return await _context.Users.FirstOrDefaultAsync(f => f.UserName == model.UserName);
        }

        public bool UserNameExist(string username)
        {
            return _context.Users.Any(x => x.UserName == username);
        }
    }
}
