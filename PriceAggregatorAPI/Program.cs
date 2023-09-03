using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using PricAggregatorAPI.Data;
using PricAggregatorAPI.Data.Repository;
using PricAggregatorAPI.Data.Repository.IRepository;
using PricAggregatorAPI.Middleware;
using PricAggregatorAPI.Models;
using PricAggregatorAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseMySQL(builder.Configuration.GetConnectionString("DefaultSqlConnection"))
);

builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ValidationExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
