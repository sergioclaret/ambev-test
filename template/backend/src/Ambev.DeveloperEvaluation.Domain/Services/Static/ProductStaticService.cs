namespace Ambev.DeveloperEvaluation.Domain.Services.Static
{
    public static class ProductStaticService
    {
        /// <summary>
        /// Calculate Price for total amount and unit price
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="unitPrice"></param>
        /// <returns></returns>
        public static decimal CalculateOriginalPrice(int totalAmount, decimal unitPrice)
        {
            return totalAmount * unitPrice;
        }

        /// <summary>
        /// Calculate Discount Percentual based on total amount and unit price
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="unitPrice"></param>
        /// <returns></returns>
        public static decimal CalculateDiscountPercentual(int totalAmount, decimal unitPrice)
        {
            if (totalAmount < 4)
                return 0;

            if (totalAmount >= 4 && totalAmount < 10)
                return 0.1m;

            if (totalAmount >= 10 && totalAmount <= 20)
                return 0.2m;

            throw new Exception("Invalid total amount");
        }

        /// <summary>
        /// Calculate Discount Value based on total amount and unit price
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="unitPrice"></param>
        /// <returns></returns>
        public static decimal CalculateDiscountValue(int totalAmount, decimal unitPrice)
        {
            return CalculateOriginalPrice(totalAmount, unitPrice) * CalculateDiscountPercentual(totalAmount, unitPrice);
        }

        /// <summary>
        /// Calculate Total based on total amount and unit price
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="unitPrice"></param>
        /// <returns></returns>
        public static decimal CalculateFinalPrice(int totalAmount, decimal unitPrice)
        {
            return CalculateOriginalPrice(totalAmount, unitPrice) - CalculateDiscountValue(totalAmount, unitPrice);
        }
    }
}
