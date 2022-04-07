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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("PcAssembly"))
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddScoped(typeof(IBaseEntity<>), typeof(BaseEntity));
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(IComponentRepository<>), typeof(ComponentRepository<>));
builder.Services.AddScoped<ICpuService, CpuService>();
builder.Services.AddScoped<ICpuRepository, CpuRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
