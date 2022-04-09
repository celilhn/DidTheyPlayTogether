using Application.Interfaces;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logging
{
    public class ApiLogger : IApiLogger
    {
        private readonly ILoggerManager logger;
        public ApiLogger(ILoggerManager logger)
        {
            this.logger = logger;
            logger.SetLogger("MovieDbRequestResponseLog");
        }

        public void Log(LogDetail logDetail)
        {
            //do nothing logger.LogInfo("");
        }
    }
}
