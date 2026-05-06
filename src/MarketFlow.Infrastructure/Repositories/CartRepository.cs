using MarketFlow.Application.Interfaces;
using MarketFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MarketFlow.Infrastructure.Repositories;

public class CartRepository(MarketFlowDbContext db) : ICartRepository
{
    public async Task GetByCustomerIdAsync(string customerId, CancellationToken ct)
        => await db.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.CustomerId.ToString() == customerId, ct);

    public async Task GetByIdAsync(Guid id, CancellationToken ct)
        => await db.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.Id == id, ct);

    public async Task UpsertAsync(Cart cart, CancellationToken ct)
    {
        // EF Core détermine automatiquement Insert vs Update via le tracking
        db.Carts.Update(cart);  // Update ajoute si non tracké, met à jour sinon
        await db.SaveChangesAsync(ct);
    }
}