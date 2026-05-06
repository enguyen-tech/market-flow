using MarketFlow.Infrastructure.Data;

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
        throw new NotImplementedException();
    }

    public Task CountAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task GetAllAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task GetPagedAsync(int page, int size, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}