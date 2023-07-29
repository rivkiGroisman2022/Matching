using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MatchingCampaignAPI
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly TextAggregation aggregations;
        public Middleware(RequestDelegate next)
        {
            _next = next;
            aggregations = new();
        }

        public async Task Invoke(HttpContext httpContext)
        {

            aggregations.Aggregate($"function: {httpContext.Request.Method}, date time: {DateTime.Now}, url: {httpContext.Request.Path}.");
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
