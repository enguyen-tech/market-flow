using System;

namespace MarketFlow.Application.Interfaces;

public interface ICartRepository
{
    // Retourne null si le client n'a pas encore de panier
    Task GetByCustomerIdAsync(string customerId, CancellationToken ct = default);

    // Retourne null si l'ID n'existe pas
    Task GetByIdAsync(Guid id, CancellationToken ct = default);

    // Upsert : crée si nouveau, met à jour si existant
    // Le handler ne distingue pas les deux cas — c'est la responsabilité du repo
    Task UpsertAsync(Cart cart, CancellationToken ct = default);
}
