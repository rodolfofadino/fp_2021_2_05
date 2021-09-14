using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Text;
using System.Threading.Tasks;

namespace fiapweb.Middlewares
{
    public class MeuMiddleware
    {
        private RequestDelegate _next;

        public MeuMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();
            //httpContext.Request.EnableRewind();

            var request = await FormatRequest(httpContext.Request);
            var logger = new LoggerConfiguration()
                .WriteTo.Logentries("ad516e04-c915-48af-93cc-e03b1ab41aae")
                .CreateLogger();

            logger.Error($"request: {request}");

            httpContext.Request.Body.Position = 0;

            await _next(httpContext);
            //logica depois
        }


        private async Task<string> FormatRequest(HttpRequest request) {
            var body = request.Body;
            //request.EnableRewind();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body = body;

            var messageObjToLog = new { scheme = request.Scheme, host = request.Host, path = request.Path, queryString = request.Query, requestBody = bodyAsText };

            return JsonConvert.SerializeObject(messageObjToLog);
        }
    }
}
