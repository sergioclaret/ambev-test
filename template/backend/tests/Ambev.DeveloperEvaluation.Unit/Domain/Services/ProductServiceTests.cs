using Ambev.DeveloperEvaluation.Domain.Services.Static;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Services
{
    public class ProductServiceTests
    {
        [Fact(DisplayName = "Test for product without discount")]
        public void Test_WithoutDiscount()
        {
            const int qtd = 2;
            const int price = 20;

            var originalPrice = ProductStaticService.CalculateOriginalPrice(qtd, price);
            var discountPercentual = ProductStaticService.CalculateDiscountPercentual(qtd, price);
            var discountValue = ProductStaticService.CalculateDiscountValue(qtd, price);
            var finalPrice = ProductStaticService.CalculateFinalPrice(qtd, price);

            Assert.Equal(40, originalPrice);
            Assert.Equal(0, discountPercentual);
            Assert.Equal(0, discountValue);
            Assert.Equal(40, finalPrice);
        }

        [Fact(DisplayName = "Test for product with 10% discount")]
        public void Test_10Discount()
        {
            const int qtd = 5;
            const int price = 20;

            var originalPrice = ProductStaticService.CalculateOriginalPrice(qtd, price);
            var discountPercentual = ProductStaticService.CalculateDiscountPercentual(qtd, price);
            var discountValue = ProductStaticService.CalculateDiscountValue(qtd, price);
            var finalPrice = ProductStaticService.CalculateFinalPrice(qtd, price);

            Assert.Equal(100, originalPrice);
            Assert.Equal(0.1m, discountPercentual);
            Assert.Equal(10, discountValue);
            Assert.Equal(90, finalPrice);
        }

        [Fact(DisplayName = "Test for product with 20% discount")]
        public void Test_20Discount()
        {
            const int qtd = 15;
            const int price = 20;

            var originalPrice = ProductStaticService.CalculateOriginalPrice(qtd, price);
            var discountPercentual = ProductStaticService.CalculateDiscountPercentual(qtd, price);
            var discountValue = ProductStaticService.CalculateDiscountValue(qtd, price);
            var finalPrice = ProductStaticService.CalculateFinalPrice(qtd, price);

            Assert.Equal(300, originalPrice);
            Assert.Equal(0.2m, discountPercentual);
            Assert.Equal(60, discountValue);
            Assert.Equal(240, finalPrice);
        }

        [Fact(DisplayName = "Test for product with more than 20 items")]
        public void Test_InvalidQuantityDiscount()
        {
            const int qtd = 25;
            const int price = 20;

            Assert.Throws<Exception>(() => ProductStaticService.CalculateDiscountPercentual(qtd, price));
        }
    }
}
