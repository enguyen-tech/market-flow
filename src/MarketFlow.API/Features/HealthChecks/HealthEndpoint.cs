namespace MarketFlow.API.Features.HealthChecks;

public static class HealthEndpoint
{
    public static IEndpointRouteBuilder MapHealth(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/health", () => Results.Ok(new { project = "MarketFlow", status = "healthy" }));
        return builder;
    }
}