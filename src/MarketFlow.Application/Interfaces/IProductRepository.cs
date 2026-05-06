public interface IProductRepository
{
    Task GetAllAsync(CancellationToken ct = default);
    Task GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Product product, CancellationToken ct = default);
    Task CountAsync(CancellationToken ct = default);                           // ← pagination
    Task GetPagedAsync(int page, int size, CancellationToken ct = default); // ← pagination
}