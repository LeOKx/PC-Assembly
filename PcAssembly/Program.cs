using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Configuration;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Bll.Services;
using PcAssembly.Dal;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Dal.Repositories;
using PcAssembly.Domain;
using PcAssembly;
using PcAssembly.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using PcAssembly.JwtFeatures;
using PcAssembly.Extensions;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowOrigin",
        builder => {

            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();

        });
});




builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("PcAssembly"))
    );
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireNonAlphanumeric = false;
    opt.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<DataContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddScoped(typeof(IComponentRepository<>), typeof(ComponentRepository<>));
builder.Services.AddScoped<ICpuService, CpuService>();
builder.Services.AddScoped<ICpuRepository, CpuRepository>();
builder.Services.AddScoped<IGraphicCardService, GraphicCardService>();
builder.Services.AddScoped<IGraphicCardRepository, GraphicCardRepository>();
builder.Services.AddScoped<IMotherboardService, MotherboardService>();
builder.Services.AddScoped<IMotherboardRepository, MotherboardRepository>();
builder.Services.AddScoped<IPowerSupplyService, PowerSupplyService>();
builder.Services.AddScoped<IPowerSupplyRepository, PowerSupplyRepository>();
builder.Services.AddScoped<IRamService, RamService>();
builder.Services.AddScoped<IRamRepository, RamRepository>();
builder.Services.AddScoped<IAcountService, AcountService>();
builder.Services.AddScoped<IAssemblyService, AssemblyService>();
builder.Services.AddScoped<IAssemblyRepository, AssemblyRepository>();
builder.Services.AddScoped<IImageService, ImageService>();



var jwtSettings = builder.Configuration.GetSection("JwtSettings");


builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
        ValidAudience = jwtSettings.GetSection("validAudience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
    };
});
builder.Services.AddScoped<JwtHandler>();





var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowOrigin");
app.UseAuthentication();
app.UseAuthorization();


app.UseDbTransaction();
app.MapControllers();

app.Run();
