using MarketFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class MigrationService(IServiceScopeFactory scopeFactory)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        using var scope = scopeFactory.CreateScope();
        var db = scope.ServiceProvider
                      .GetRequiredService<MarketFlowDbContext>();

        // Applique toutes les migrations non encore appliquées
        await db.Database.MigrateAsync(ct);
    }
}