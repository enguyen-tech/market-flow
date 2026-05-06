using MarketFlow.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MarketFlow.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection s)
        => s.AddScoped<ICartRepository, ICartRepository>()
            .AddScoped<IProductRepository, IProductRepository>();
}