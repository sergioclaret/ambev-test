using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services.Static;
using AutoMapper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Services
{
    public class SaleServiceTests
    {
        private readonly IMapper _mapper;

        public SaleServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CreateSaleProfile());
            });

            _mapper = config.CreateMapper();
        }

        [Fact(DisplayName = "Test calc of products")]
        public void Given_SuspendedUser_When_Activated_Then_StatusShouldBeActive()
        {
            var command = new CreateSaleCommand
            {
                Products =
                [
                    new() { Quantity = 5, UnitPrice = 90 },
                    new() { Quantity = 10, UnitPrice = 100 },
                ]
            };
            var sale = _mapper.Map<Sale>(command);

            var originalPrice = SaleStaticService.CalculateOriginalPrice(sale.Products);
            var discountValue = SaleStaticService.CalculateDiscountValue(sale.Products);
            var totalAmount = SaleStaticService.CalculateFinalPrice(sale.Products);

            Assert.Equal(1450, originalPrice);
            Assert.Equal(245, discountValue);
            Assert.Equal(1205, totalAmount);
        }
    }
}
