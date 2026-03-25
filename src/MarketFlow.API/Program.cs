using MarketFlow.API.Features.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddOpenApi();

var app = builder.Build();
app.MapOpenApi();
app.UseAuthentication();
app.UseAuthorization();
app.MapHealth();
app.Run();
