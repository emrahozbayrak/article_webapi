
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Log
{
    public class LoggerProvider : ILoggerProvider
    {
        private string _contentRootPath;
        public LoggerProvider(string contentRootPath) 
        {
            _contentRootPath = contentRootPath;
        }
        public ILogger CreateLogger(string categoryName) => new Logger(_contentRootPath);
        public void Dispose() => throw new NotImplementedException();

    }
}
