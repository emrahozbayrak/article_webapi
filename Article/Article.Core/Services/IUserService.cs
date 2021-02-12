using Article.Core.Models;
using Article.Core.Utilities.Results;
using Article.Core.Utilities.UserResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Core.Services
{
    public interface IUserService //: IService<Article.Core.Entities.User>
    {
        Article.Core.Entities.User GetById(long id);
        Task<IUserResult> LoginAsync(AuthenticateUserModel model);
        Task<IResult> RegisterAsync(CreateUserModel model);
        IResult UpdateUser(UpdateUserModel model);
        IResult DeleteUser(Article.Core.Entities.User model);
        IResult DeleteUser(long id);
    }
}
