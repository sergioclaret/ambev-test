namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateProductRequest
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
    }
}
