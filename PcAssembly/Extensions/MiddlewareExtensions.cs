using PcAssembly.Middlewares;

namespace PcAssembly.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseDbTransaction(this IApplicationBuilder app) => 
            app.UseMiddleware<DbTransactionMiddleware>();
    }
}
