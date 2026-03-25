public abstract class BaseEntity<TId>
{
    public TId Id { get; protected set; } = default!;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    // EF Core compare les entités par Id de base (pas de référence)
    public override bool Equals(object? obj)
        => obj is BaseEntity<TId> other && EqualityComparer<TId>.Default.Equals(Id, other.Id);
    public override int GetHashCode() => Id!.GetHashCode();
}