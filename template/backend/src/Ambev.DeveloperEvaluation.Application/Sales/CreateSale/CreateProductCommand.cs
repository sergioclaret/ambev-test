namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateProductCommand
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
    }
}
