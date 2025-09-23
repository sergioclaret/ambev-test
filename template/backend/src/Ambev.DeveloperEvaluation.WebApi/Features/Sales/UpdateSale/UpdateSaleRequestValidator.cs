using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator() 
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
                .SetValidator(new UpdateProductRequestValidator());
        }
    }
}
