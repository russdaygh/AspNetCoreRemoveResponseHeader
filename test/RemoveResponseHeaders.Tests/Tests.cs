using Microsoft.AspNetCore.Http;
using RemoveResponseHeaders;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly RequestDelegate _mockRequestDelegate = (context) => Task.FromResult(0);
        
        [Fact]
        public async void Invoke_RemovesResponseHeader_WhenResponseHeaderSet()
        {
            const string responseHeader = "responseHeader";

            var middleware = new RemoveResponseHeadersMiddleware(_mockRequestDelegate,
                new RemoveResponseHeadersOptions(new[] { responseHeader }));

            var context = new DefaultHttpContext();
            context.Response.Headers.Add(responseHeader, "value");

            await middleware.Invoke(context);

            Assert.DoesNotContain(context.Response.Headers, kvp => kvp.Key == responseHeader);
        }
    }
}
