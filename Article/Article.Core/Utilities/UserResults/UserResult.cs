using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Core.Utilities.UserResults
{
    public class UserResult : IUserResult
    {
        public bool Success { get; }
        public string Message { get; }

        public Dictionary<string, string> UserInfo { get; }

        public DateTime? ExpireDate { get;  }

        public UserResult(Dictionary<string, string> userInfo, DateTime expireDate, bool success, string message)
        {
            UserInfo = userInfo;
            ExpireDate = expireDate;
            Message = message;
            Success = success;
        }

        public UserResult(bool success, string message)
        {
            Message = message;
            Success = success;
        }

        public UserResult(bool success)
        {
            Success = success;
        }
  
    }
}
