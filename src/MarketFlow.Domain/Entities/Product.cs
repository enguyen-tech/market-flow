public sealed class Product : BaseEntity<Guid>
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    private Product() { } // EF Core 10 — reconstitution depuis la DB

    public static Product Create(string name, decimal price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name is required");
        if (price <= 0)
            throw new DomainException("Price must be positive");
        if (stock < 0)
            throw new DomainException("Stock cannot be negative");

        return new() { Id = Guid.NewGuid(), Name = name, Price = price, Stock = stock };
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0) throw new DomainException("Price must be positive");
        Price = newPrice;
    }

    public void DecrementStock(int quantity)
    {
        if (quantity > Stock) throw new DomainException("Insufficient stock");
        Stock -= quantity;
    }
}