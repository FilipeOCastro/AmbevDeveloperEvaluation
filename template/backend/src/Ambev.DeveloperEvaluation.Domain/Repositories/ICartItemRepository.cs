using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICartItemRepository
    {
        Task<CartItem> CreateAsync(CartItem cartItem, CancellationToken cancellationToken = default);

        Task<CartItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<CartItem>> GetByCartIdAsync(Guid cartId, CancellationToken cancellationToken = default);

        Task<IEnumerable<CartItem>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<CartItem> UpdateAsync(CartItem cartItem, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> DeleteByCartIdAsync(Guid cartId, CancellationToken cancellationToken = default);
    }
}
