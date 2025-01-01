using CleanArchAndCQRS.Infrastructure;
using CleanArchAndCQRS.Infrastructure.Logging;
using CleanArchAndCQRS.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseShared();
app.UseMiddleware<LoggingMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
