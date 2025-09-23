namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleResult
    {

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
        /// Total price for the product (UnitPrice * Quantity)
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
