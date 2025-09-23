namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetProductResponse
    {
        /// <summary>
        /// Product identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unit product price
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Product quantity in sale
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Original total price before discount
        /// </summary>
        public decimal OriginalTotalPrice { get; set; }

        /// <summary>
        /// Discount percentual applied to the product
        /// </summary>
        public decimal DiscountPercentual { get; set; }

        /// <summary>
        /// Discount value applied to the product
        /// </summary>
        public decimal DiscountValue { get; set; }

        /// <summary>
        /// Total price after discount
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
