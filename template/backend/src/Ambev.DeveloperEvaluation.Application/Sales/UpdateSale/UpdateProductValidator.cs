using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Quantity)
                .LessThanOrEqualTo(20)
                .WithMessage("Product quantity must be less than or equal to 20.");
        }
    }
}
