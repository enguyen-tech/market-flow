using MarketFlow.Application.Interfaces;
using MarketFlow.Infrastructure.Data;
using MarketFlow.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarketFlow.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection s, IConfiguration configuration)
        => s.AddScoped<ICartRepository, CartRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddDbContext<MarketFlowDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("marketflowdb")));

}