using BlogBackend.WebApi;
using BlogBackend.Infrastructure;
using BlogBackend.Application;
using Scalar.AspNetCore;
using BlogBackend.WebApi.Modules;
using BlogBackend.WebApi.Middlewares;
using BlogBackend.WebApi.Controllers.OData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomData();
builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddWebApi();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseExceptionHandler();

app.UseAuthorization();

app.UseRateLimiter();

app.MapControllers().RequireRateLimiting("fixed");

app.MapEndpoints();

app.Run();
