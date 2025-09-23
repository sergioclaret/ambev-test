using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        /// <summary>
        /// Creates a new sale in the repository
        /// </summary>
        /// <param name="sale"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Created sale</returns>
        Task<Sale> CreateAsync(Sale product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all sales in the repository
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List of sales</returns>
        Task<List<Sale>> ListAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a sale by its unique identifier
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The sale if found, null otherwise</returns>
        Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing sale in the repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sale"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The sale if found, null otherwise</returns>
        Task<Sale?> UpdateAsync(Guid id, Sale product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a sale from the repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if the sale was deleted, false if not found</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
