using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public sealed class ApplicationAssemblyMarker { }

    public static IServiceCollection AddApplicationLayer(this IServiceCollection s)
        => s.AddMediatR(cfg =>
               cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));
}