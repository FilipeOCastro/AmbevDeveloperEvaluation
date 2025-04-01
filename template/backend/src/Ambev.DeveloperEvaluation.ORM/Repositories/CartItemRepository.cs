using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly DbContext _context;

        public CartItemRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<CartItem> CreateAsync(CartItem cartItem, CancellationToken cancellationToken = default)
        {
            await _context.Set<CartItem>().AddAsync(cartItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return cartItem;
        }

        public async Task<CartItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<CartItem>().FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<IEnumerable<CartItem>> GetByCartIdAsync(Guid cartId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<CartItem>().Where(c => c.CartId == cartId).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<CartItem>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<CartItem>().ToListAsync(cancellationToken);
        }

        public async Task<CartItem> UpdateAsync(CartItem cartItem, CancellationToken cancellationToken = default)
        {
            _context.Set<CartItem>().Update(cartItem);
            await _context.SaveChangesAsync(cancellationToken);
            return cartItem;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var cartItem = await _context.Set<CartItem>().FindAsync(new object[] { id }, cancellationToken);
            if (cartItem == null)
                return false;

            _context.Set<CartItem>().Remove(cartItem);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteByCartIdAsync(Guid cartId, CancellationToken cancellationToken = default)
        {
            var cartItems = await GetByCartIdAsync((object)cartId);
            if (!cartItems.Any())
                return false;

            _context.Set<CartItem>().RemoveRange(cartItems);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        private async Task<CartItem[]> GetByCartIdAsync(object cartId)
        {
            throw new NotImplementedException();
        }
    }
}
