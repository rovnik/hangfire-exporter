using HangfireExporter.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
     .AddEnvironmentVariables("HE_");

IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHangfireForMetrics(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
