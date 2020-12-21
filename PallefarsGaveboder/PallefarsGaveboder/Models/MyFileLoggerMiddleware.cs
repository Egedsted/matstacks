using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PallefarsGaveboder.Models
{
    public class MyFileLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly MyFileLoggerOptions _options;
        public MyFileLoggerMiddleware(RequestDelegate next, IOptions<MyFileLoggerOptions> options)
        {
            _next = next;
            _options = options.Value;
        }
        public async Task Invoke(HttpContext context)
        {

            var request = context.Request;
            var requestLogMessage = $"REQUEST:\n{request.Method} - {request.Path.Value}{request.QueryString}";
            requestLogMessage += $"\nContentType: {request.ContentType ?? "Not specified"}";
            requestLogMessage += $"\nHost: {request.Host}";
            File.AppendAllText(_options.FileName, $"{DateTime.Now.ToString("s")}\n{requestLogMessage}");

            await _next(context);

            var response = context.Response;
            var responseLogMessage = $"\nRESPONSE:\nStatus Code: {response.StatusCode}";
            File.AppendAllText(_options.FileName, $"{responseLogMessage}\n\n");
        }
    }
}
