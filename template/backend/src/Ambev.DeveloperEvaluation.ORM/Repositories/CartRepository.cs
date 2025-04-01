using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DbContext _context;

        public CartRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            await _context.Set<Cart>().AddAsync(cart, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return cart;
        }

        public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Cart>()
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<Cart?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Cart>()
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.UserId == userId && !s.IsCancelled, cancellationToken);
        }

        public async Task<IEnumerable<Cart>> GetAllAsync(int page, int size, string order, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<Cart>().AsQueryable();

            if (!string.IsNullOrEmpty(order))
                query = query.OrderBy(order);

            return await query.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Cart>().CountAsync(cancellationToken);
        }

        public async Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            _context.Set<Cart>().Update(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return cart;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var cart = await _context.Set<Cart>().FindAsync(new object[] { id }, cancellationToken);
            if (cart == null)
                return false;

            _context.Set<Cart>().Remove(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
