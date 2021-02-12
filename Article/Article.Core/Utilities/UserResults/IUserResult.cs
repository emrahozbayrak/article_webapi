using Article.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Core.Utilities.UserResults
{
    public interface IUserResult : IResult
    {
        public Dictionary<string, string> UserInfo { get; }
        public DateTime? ExpireDate { get; }
    }
}
