using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IProductRepository using Entity Framework Core
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of ProductRepository
        /// </summary>
        /// <param name="context"></param>
        public ProductRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new product in the repository
        /// </summary>
        /// <param name="product"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Product> CreateAsync(Product product, 
            CancellationToken cancellationToken = default)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        /// <summary>
        /// Lists all products in the repository
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<Product>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Gets a product by its unique identifier
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Product?> GetByIdAsync(Guid id, 
            CancellationToken cancellationToken = default)
        {
            return await _context.Products.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        /// <summary>
        /// Updates an existing product in the repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Product?> UpdateAsync(Guid id, Product product, 
            CancellationToken cancellationToken = default)
        {
            var currentProduct = await GetByIdAsync(id, cancellationToken);

            if (currentProduct == null)
                return null;

            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }

        /// <summary>
        /// Deletes a product from the repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var product = await GetByIdAsync(id, cancellationToken);

            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
