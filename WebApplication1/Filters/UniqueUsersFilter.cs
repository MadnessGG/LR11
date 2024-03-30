namespace WebApplication1.Filters
{

    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.IO;

        public class UniqueUsersFilter : IActionFilter
        {
            private readonly string _logFilePath;

            public UniqueUsersFilter(string logFilePath)
            {
                _logFilePath = logFilePath;
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                string ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
                string logMessage = $"{DateTime.Now}: User with IP {ipAddress} accessed the application\n";

                File.AppendAllText(_logFilePath, logMessage);
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                // Do nothing
            }
       }
    

}
