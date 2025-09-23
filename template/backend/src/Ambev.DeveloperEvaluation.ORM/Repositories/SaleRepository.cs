using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of ISaleRepository using Entity Framework Core
    /// </summary>
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleRepository
        /// </summary>
        /// <param name="context"></param>
        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new sale in the repository
        /// </summary>
        /// <param name="sale"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Sale> CreateAsync(Sale sale,
            CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }

        /// <summary>
        /// Lists all sale in the repository
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<Sale>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Sales.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Gets a sale by its unique identifier
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Sale?> GetByIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _context.Sales
                .Include(x => x.Products)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        /// <summary>
        /// Updates an existing sale in the repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sale"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Sale?> UpdateAsync(Guid id, Sale sale,
            CancellationToken cancellationToken = default)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync(cancellationToken);

            return sale;
        }

        /// <summary>
        /// Deletes a sale from the repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var sale = await GetByIdAsync(id, cancellationToken);

            if (sale == null)
                return false;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
