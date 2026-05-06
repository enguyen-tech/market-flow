using Microsoft.EntityFrameworkCore;

namespace MarketFlow.Infrastructure.Data;

public class MarketFlowDbContext(DbContextOptions<MarketFlowDbContext> options)
    : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Cart> Carts => Set<Cart>();

    protected override void OnModelCreating(ModelBuilder model)
        => model.ApplyConfigurationsFromAssembly(typeof(MarketFlowDbContext).Assembly);
}