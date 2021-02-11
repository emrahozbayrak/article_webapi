using Article.Core.Models;
using Article.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Core.Services
{
    public interface IUserService //: IService<Article.Core.Entities.User>
    {
        Task<IDataResult<Article.Core.Entities.User>> LoginAsync(AuthenticateRequest model);
        Task<IResult> RegisterAsync(RegisterRequest model);
        Task<IResult> UpdateUser(Article.Core.Entities.User model);
        Task<IResult> DeleteUser(Article.Core.Entities.User model);
        Task<IResult> DeleteUser(long id);
    }
}
