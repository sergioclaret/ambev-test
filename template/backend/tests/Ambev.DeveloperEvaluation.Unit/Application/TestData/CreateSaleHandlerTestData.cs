using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    public static class CreateSaleHandlerTestData
    {
        private static readonly Faker<CreateSaleCommand> createSaleHandlerFaker
            = new Faker<CreateSaleCommand>()
            .RuleFor(s => s.Number, f => f.Random.Number(1000, 9999).ToString())
            .RuleFor(s => s.Date, f => f.Date.Recent())
            .RuleFor(Random => Random.CustomerId, f => f.Random.Guid())
            .RuleFor(s => s.CustomerName, f => f.Name.FullName())
            .RuleFor(s => s.BranchId, f => f.Random.Guid())
            .RuleFor(s => s.BranchName, f => f.Company.CompanyName())
            .RuleFor(s => s.Products, f =>
            [
                new Faker<CreateProductCommand>()
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(80, 100))
                    .RuleFor(p => p.Quantity, f => f.Random.Int(1, 3))
                    .Generate(),
                new Faker<CreateProductCommand>()
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(80, 100))
                    .RuleFor(p => p.Quantity, f => f.Random.Int(4, 9))
                    .Generate(),
                new Faker<CreateProductCommand>()
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(80, 100))
                    .RuleFor(p => p.Quantity, f => f.Random.Int(10, 20))
                    .Generate()
            ]);

        private static readonly Faker<CreateSaleCommand> createInvalidSaleHandlerFaker
            = new Faker<CreateSaleCommand>()
            .RuleFor(s => s.Number, f => f.Random.Number(1000, 9999).ToString())
            .RuleFor(s => s.Date, f => f.Date.Recent())
            .RuleFor(Random => Random.CustomerId, f => f.Random.Guid())
            .RuleFor(s => s.CustomerName, f => f.Name.FullName())
            .RuleFor(s => s.BranchId, f => f.Random.Guid())
            .RuleFor(s => s.BranchName, f => f.Company.CompanyName())
            .RuleFor(s => s.Products, f =>
            [
                new Faker<CreateProductCommand>()
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(80, 100))
                    .RuleFor(p => p.Quantity, f => f.Random.Int(21, 99))
                    .Generate()
            ]);


        public static CreateSaleCommand GenerateValidCommand()
        {
            return createSaleHandlerFaker.Generate();
        }
        public static CreateSaleCommand GenerateInvalidCommand()
        {
            return createInvalidSaleHandlerFaker.Generate();
        }
    }
}
