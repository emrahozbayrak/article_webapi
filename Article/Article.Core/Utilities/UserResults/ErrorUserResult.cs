using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Core.Utilities.UserResults
{
    public class ErrorUserResult : UserResult
    {
        public ErrorUserResult(string message)
           : base(false, message)
        {
        }

        public ErrorUserResult()
         : base(false)
        {
        }
    }
}
