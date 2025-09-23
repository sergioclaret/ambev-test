using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services.Static
{
    public static class SaleStaticService
    {
        /// <summary>
        /// Calculate Price for total amount and unit price
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="unitPrice"></param>
        /// <returns></returns>
        public static decimal CalculateOriginalPrice(List<Product> products)
        {
            return products.Sum(x => x.OriginalTotalPrice);
        }

        /// <summary>
        /// Calculate Discount Value based on total amount and unit price
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="unitPrice"></param>
        /// <returns></returns>
        public static decimal CalculateDiscountValue(List<Product> products)
        {
            return products.Sum(x => x.DiscountValue);
        }

        /// <summary>
        /// Calculate Total based on total amount and unit price
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="unitPrice"></param>
        /// <returns></returns>
        public static decimal CalculateFinalPrice(List<Product> products)
        {
            return products.Sum(x => x.TotalAmount);
        }
    }
}
