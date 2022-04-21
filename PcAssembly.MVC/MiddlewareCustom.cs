namespace PcAssembly.MVC
{
    public class MiddlewareCustom
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<MiddlewareCustom> _logger;
        public MiddlewareCustom(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory?.CreateLogger<MiddlewareCustom>() ??
            throw new ArgumentNullException(nameof(loggerFactory));
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Request URL: {Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
            await this._next(context);
        }

    }
}
