using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RemoveResponseHeaders
{
    public class RemoveResponseHeadersMiddleware
    {
        private readonly RemoveResponseHeadersOptions _options;
        private readonly RequestDelegate _next;

        public RemoveResponseHeadersMiddleware(RequestDelegate next, RemoveResponseHeadersOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            _next = next;
            _options = options;
        }

        public Task Invoke(HttpContext context)
        {
            _options.HeaderNames.ToList().ForEach(header => context.Response.Headers.Remove(header));

            _next(context);

            return Task.FromResult(0);
        }
    }
}
