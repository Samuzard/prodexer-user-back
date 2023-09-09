using Microsoft.EntityFrameworkCore;
using PricAggregatorAPI.Middleware;
using PricAggregatorAPI.Utils;
using PriceAggregator.Core.IRepository;
using PriceAggregator.Infrastructure;
using PriceAggregator.Infrastructure.Repository;

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

builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
