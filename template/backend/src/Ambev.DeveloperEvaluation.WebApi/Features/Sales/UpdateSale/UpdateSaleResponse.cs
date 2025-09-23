using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleResponse
    {
        /// <summary>
        /// Sale ID
        /// </summary>
        public Guid Id { get; set; }

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
        /// Sale status
        /// </summary>
        public SaleStatus SaleStatus { get; set; }

        /// <summary>
        /// Original total price before discount
        /// </summary>
        public decimal OriginalTotalPrice { get; set; }

        /// <summary>
        /// Discount value applied to the product
        /// </summary>
        public decimal DiscountValue { get; set; }

        /// <summary>
        /// Total amount of the sale
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// List of products in the sale
        /// </summary>
        public List<UpdateProductResponse> Products { get; set; }
    }
}
