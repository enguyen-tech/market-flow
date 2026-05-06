using Microsoft.AspNetCore.Diagnostics;
using MarketFlow.API.Features.HealthChecks;
using MarketFlow.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddOpenApi()
    .AddApplicationLayer()
    .AddInfrastructureLayer();

var app = builder.Build();

app.UseExceptionHandler(err => err.Run(async ctx =>
{
    var ex = ctx.Features.Get<IExceptionHandlerFeature>()?.Error;
    ctx.Response.StatusCode = ex switch
    {
        DomainException => 400,
        NotFoundException => 404,
        UnauthorizedAccessException => 401,
        _ => 500
    };
    await ctx.Response.WriteAsJsonAsync(new { error = ex?.Message });
}));

app.MapOpenApi();
app.UseAuthentication();
app.UseAuthorization();
app.MapHealth();
app.Run();