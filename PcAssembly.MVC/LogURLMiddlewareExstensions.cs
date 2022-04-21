namespace PcAssembly.MVC
{
    public static class LogURLMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MiddlewareCustom>();
        }
    }
}
