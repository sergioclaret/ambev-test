using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty();

            RuleFor(x => x.Date)
                .NotEmpty();

            RuleFor(x => x.CustomerId)
                .NotEmpty();

            RuleFor(x => x.CustomerName)
                .NotEmpty();

            RuleFor(x => x.BranchId)
                .NotEmpty();

            RuleFor(x => x.BranchName)
                .NotEmpty();

            RuleFor(x => x.Products)
                .NotEmpty();

            RuleForEach(x => x.Products)
                .SetValidator(new CreateProductRequestValidator());
        }
    }
}
