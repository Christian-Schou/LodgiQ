using System.Reflection;
using HealthChecks.UI.Client;
using Lodgingly.Api.Extensions;
using Lodgingly.Api.Middleware;
using Lodgingly.Api.OpenTelemetry;
using Lodgingly.Framework.Application;
using Lodgingly.Framework.Infrastructure;
using Lodgingly.Framework.Infrastructure.Extensions;
using Lodgingly.Framework.Presentation.Endpoints.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Register logging service
builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

// Exception handling
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// API Documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

// Register modules
Assembly[] modules = [];
builder.Services.AddApplicationFramework(modules);

// Get connection strings
string dbConnectionString = builder.Configuration.GetConnectionStringOrThrow("Database");
string redisConnectionString = builder.Configuration.GetConnectionStringOrThrow("Cache");

builder.Services.AddInfrastructureFramework(
    DiagnosticsConfig.ServiceName, 
    [],
    dbConnectionString,
    redisConnectionString);

Uri keyCloakHealthUrl = builder.Configuration.GetKeyCloakHealthCheckUrl();

builder.Services.AddHealthChecks()
    .AddNpgSql(dbConnectionString)
    .AddRedis(redisConnectionString)
    .AddKeyCloak(keyCloakHealthUrl);

builder.Configuration.InitializeModuleConfigurations(["users"]);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseLogContext();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

app.MapEndpoints();

app.Run();

public partial class Program;