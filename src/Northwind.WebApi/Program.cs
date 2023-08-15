using Microsoft.EntityFrameworkCore;

using Northwind.Application.Queries;
using Northwind.Application.Services;
using Northwind.Domain.Production;
using Northwind.Infrastructure;
using Northwind.Infrastructure.Queries;
using Northwind.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(connectionString);
    options.EnableSensitiveDataLogging(true);
});

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICategoriesQueries, CategoriesQueries>();
builder.Services.AddScoped<ICategoryReadOnlyRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryWriteOnlyRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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