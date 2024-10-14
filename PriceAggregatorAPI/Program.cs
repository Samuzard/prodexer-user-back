using Microsoft.EntityFrameworkCore;
using PriceAggregatorAPI.Middleware;
using PriceAggregator.Core.IRepository;
using PriceAggregator.Infrastructure;
using PriceAggregator.Infrastructure.Repository;
using PriceAggregatorAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultSqlConnection"))
);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ValidationExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
