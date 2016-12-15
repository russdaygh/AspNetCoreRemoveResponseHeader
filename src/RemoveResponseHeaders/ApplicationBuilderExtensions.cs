using Microsoft.AspNetCore.Builder;

namespace RemoveResponseHeaders
{
    public static class ApplicationBuilderExtensions
    {
        public static void RemoveResponseHeaders(this IApplicationBuilder app, params string[] headerNames)
        {
            app.UseMiddleware<RemoveResponseHeadersMiddleware>(
                new RemoveResponseHeadersOptions(headerNames));
        }

        public static void RemoveAspNetHeaders(this IApplicationBuilder app)
        {
            app.UseMiddleware<RemoveResponseHeadersMiddleware>(
                new RemoveResponseHeadersOptions(new[] {
                "Server",
                "X-AspNet-Version",
                "X-AspNetMvc-Version",
                "X-Powered-By"}));
        }
    }
}
