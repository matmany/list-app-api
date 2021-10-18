using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ListApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new() { Title = "ListApi", Version = "v1" });
});

builder.Services.AddDbContext<ListApiContext>(options =>
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("ListApiContext"))
        .UseSnakeCaseNamingConvention()
        .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
        .EnableSensitiveDataLogging()
        );

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  ///app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ListApi v1"));
  app.UseSwaggerUI(c=> {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "VehicleQuotes v1");
    c.RoutePrefix = "";
  });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
