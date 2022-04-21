namespace PcAssembly.MVC
{
    public class MiddlewareExp
    {
        public static void HelloWorldRequest(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Hello World {context.Request.Path}");
            });
        }

        public static void X2Mulitiplier(IApplicationBuilder app)
        {
            int x = 2;
            app.Run(async (context) =>
            {
                x = x * 2;
                await context.Response.WriteAsync($" Result: {x}");
            });
        }
    }
}
