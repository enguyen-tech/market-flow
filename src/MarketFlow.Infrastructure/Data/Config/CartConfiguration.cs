using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketFlow.Infrastructure.Data;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> b)
    {
        b.ToTable("carts");
        b.HasKey(c => c.Id);
        b.Ignore(c => c.Total); // propriété calculée, pas de colonne

        // Accès au champ privé _items de l'agrégat
        b.HasMany(c => c.Items)
         .WithOne()
         .HasForeignKey("CartId")
         .OnDelete(DeleteBehavior.Cascade);
        b.Navigation(c => c.Items)
         .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}