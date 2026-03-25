public sealed class Cart : BaseEntity<Guid>
{
    public Guid CustomerId { get; private set; }
    private readonly List<CartItem> _items = new();
    public IReadOnlyList<CartItem> Items => _items.AsReadOnly();

    // Calculé dynamiquement — jamais stocké en base
    public decimal Total => _items.Sum(i => i.Quantity * i.UnitPrice);

    private Cart() { }

    public static Cart Create(Guid customerId)
        => new() { Id = Guid.NewGuid(), CustomerId = customerId };

    public void AddItem(Guid productId, string name, decimal price, int qty)
    {
        if (qty <= 0) throw new DomainException("Quantity must be positive");

        // Règle métier : fusionner si le produit existe déjà
        var existing = _items.FirstOrDefault(i => i.ProductId == productId);
        if (existing is not null)
            existing.IncreaseQuantity(qty);
        else
            _items.Add(CartItem.Create(productId, name, price, qty));
    }

    public void RemoveItem(Guid productId)
        => _items.RemoveAll(i => i.ProductId == productId);
}