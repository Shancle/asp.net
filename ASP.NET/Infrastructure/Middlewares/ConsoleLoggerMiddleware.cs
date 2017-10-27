using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ASP.NET.Infrastructure.Middlewares
{
    public class ConsoleLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public ConsoleLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("User-Agent"))
            {
                Console.WriteLine($"useragent: {context.Request.Headers["User-Agent"]}");
            }
            if(context.Request.QueryString.HasValue)
            {
                Console.WriteLine($"query string: {context.Request.QueryString.Value}");
            }
            await _next(context);
        }
    }
}