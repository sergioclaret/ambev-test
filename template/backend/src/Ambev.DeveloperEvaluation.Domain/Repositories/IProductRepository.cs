using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Creates a new product in the repository
        /// </summary>
        /// <param name="product"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Created product</returns>
        Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all products in the repository
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List of products</returns>
        Task<List<Product>> ListAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a product by its unique identifier
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The product if found, null otherwise</returns>
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing product in the repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The product if found, null otherwise</returns>
        Task<Product?> UpdateAsync(Guid id, Product product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a product from the repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if the product was deleted, false if not found</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
