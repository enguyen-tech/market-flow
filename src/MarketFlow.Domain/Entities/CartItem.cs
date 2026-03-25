public sealed class CartItem : BaseEntity<Guid>
{
    public Guid ProductId { get; private set; }
    public string Name { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }

    private CartItem() { }

    public static CartItem Create(Guid productId, string name, decimal unitPrice, int quantity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name is required");
        if (unitPrice <= 0)
            throw new DomainException("Unit price must be positive");
        if (quantity <= 0)
            throw new DomainException("Quantity must be positive");

        return new() { Id = Guid.NewGuid(), ProductId = productId, Name = name, UnitPrice = unitPrice, Quantity = quantity };
    }

    public void IncreaseQuantity(int qty)
    {
        if (qty <= 0) throw new DomainException("Quantity to increase must be positive");
        Quantity += qty;
    }
}