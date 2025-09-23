namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        /// <summary>
        /// Sale Number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Date when the sale was made
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Customer ID
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Customer Name
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Branch ID where the sale was made
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Branch Name where the sale was made
        /// </summary>
        public string BranchName { get; set; }

        /// <summary>
        /// List of products in the sale
        /// </summary>
        public List<CreateProductRequest> Products { get; set; }
    }
}
