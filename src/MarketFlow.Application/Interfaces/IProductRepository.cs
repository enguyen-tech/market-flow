public interface IProductRepository
{
    Task<List<Product>> GetAllAsync(CancellationToken ct = default);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Product product, CancellationToken ct = default);
    Task<int> CountAsync(CancellationToken ct = default);                           // ← pagination
    Task<List<Product>> GetPagedAsync(int page, int size, CancellationToken ct = default); // ← pagination
}