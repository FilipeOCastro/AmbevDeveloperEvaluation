using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _context;

        public ProductRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Set<Product>().AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>().FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>().FirstOrDefaultAsync(p => p.Title == title, cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int page, int size, string order, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<Product>().AsQueryable();

            if (!string.IsNullOrEmpty(order))
                query = query.OrderBy(order);

            return await query.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>().CountAsync(cancellationToken);
        }

        public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            _context.Set<Product>().Update(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await _context.Set<Product>().FindAsync(new object[] { id }, cancellationToken);
            if (product == null)
                return false;

            _context.Set<Product>().Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<string>> GetCategoriesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>().Select(p => p.Category).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(string category, int page, int size, string order,
            CancellationToken cancellationToken = default)
        {
            var query = _context.Set<Product>().Where(p => p.Category == category);

            if (!string.IsNullOrEmpty(order))
                query = query.OrderBy(order);

            return await query.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);
        }

        public async Task<int> CountByCategoryAsync(string category, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>().CountAsync(p => p.Category == category, cancellationToken);
        }
    }
}
