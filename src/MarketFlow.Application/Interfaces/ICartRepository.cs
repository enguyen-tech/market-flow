using System;

namespace MarketFlow.Application.Interfaces;

public interface ICartRepository
{
        Task GetByUserIdAsync(Guid userId, CancellationToken ct = default);
        Task AddAsync(Cart cart, CancellationToken ct = default);
        Task UpdateAsync(Cart cart, CancellationToken ct = default);
}
