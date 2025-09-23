using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {
        /// <summary>
        /// Foreign Key for sale
        /// </summary>
        public Guid SaleId { get; set; }

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
