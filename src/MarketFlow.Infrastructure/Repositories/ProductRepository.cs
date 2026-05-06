using MarketFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MarketFlow.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly MarketFlowDbContext db;

    public ProductRepository(MarketFlowDbContext db)
    {
        this.db = db;
    }

    public Task AddAsync(Product product, CancellationToken ct = default)
    {
        db.Products.Add(product);
        return db.SaveChangesAsync(ct);
    }

    public Task<int> CountAsync(CancellationToken ct = default)
    {
        return db.Products.CountAsync(ct);
    }

    public Task<List<Product>> GetAllAsync(CancellationToken ct = default)
    {
        return db.Products.ToListAsync(ct);
    }

    public Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return db.Products.FirstOrDefaultAsync(p => p.Id == id, ct);
    }

    public Task<List<Product>> GetPagedAsync(int page, int size, CancellationToken ct = default)
    {
        return db.Products.Skip((page - 1) * size).Take(size).ToListAsync(ct);
    }
}