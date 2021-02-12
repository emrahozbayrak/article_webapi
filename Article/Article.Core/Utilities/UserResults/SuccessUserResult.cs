using Article.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Core.Utilities.UserResults
{
    public class SuccessUserResult : UserResult
    {

        public SuccessUserResult(Dictionary<string, string> userInfo, DateTime expireDate, string message)
            :base (userInfo,expireDate,true,message)
        {
        }

    }
}
