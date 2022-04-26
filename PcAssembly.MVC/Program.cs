using Microsoft.EntityFrameworkCore;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Bll.Services;
using PcAssembly.Dal;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Dal.Repositories;
using PcAssembly.MVC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("PcAssembly"))
    );

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICpuService, CpuService>();
builder.Services.AddScoped<ICpuRepository, CpuRepository>();

var app = builder.Build();

//app.UseWelcomePage(); //WelcomePageMiddleware

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Shared/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseLogUrl();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Map("/Time", (ILogger<Program> logger) =>
{
    logger.LogInformation($"Time: {DateTime.Now.ToLongTimeString()}");
    return $"Time {DateTime.Now.ToLongTimeString()}";
});
app.Map("/Hello", MiddlewareExp.HelloWorldRequest);
app.Map("/counter", MiddlewareExp.X2Mulitiplier);
app.Map("/Error", ErrorRequst);

//app.Use(async (context, next) =>
//{
//    var path = context.Request.Path;
//    app.Logger.LogCritical($"LogCritical {path}");
//    app.Logger.LogError($"LogError {path}");
//    app.Logger.LogInformation($"LogInformation {path}");
//    app.Logger.LogWarning($"LogWarning {path}");
//    await context.Response.WriteAsync("<h1>Hello World! </h1>");
//    await next.Invoke(context);
//});

//app.Use(async (context, next) =>
//{
//    await HandleRequst(context, next);
//});

//int x = 2;
//app.Use(async (context, next) =>
//{
//    await CounterRequst(x, context, next);
//});

////int x = 2;
//app.Run(async (context) =>
//{
//    x = x * 2;  //  2 * 2 = 4
//    await context.Response.WriteAsync($" Result: {x}");

//});
//app.Run(async (context) => await context.Response.WriteAsync($"Path: {context.Request.Path}"));
//app.UseMiddleware<MiddlewareCustom>();

app.Run();


async Task HandleRequst(HttpContext context, RequestDelegate next)
{
    await context.Response.WriteAsync("Hello World! ");
    await next.Invoke(context);
    
}

async Task CounterRequst(int x, HttpContext context, RequestDelegate next)
{
    x = x * 2;  //  2 * 2 = 4
    await context.Response.WriteAsync($" Result: {x}");
    await next.Invoke(context);

}

async Task ErrorRequst(int x, HttpContext context, RequestDelegate next)
{
    await context.Response.WriteAsync($"Error");
    await next.Invoke(context);

}



