using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator() 
        {
            RuleFor(x => x.Quantity)
                .LessThanOrEqualTo(20)
                .WithMessage("Product quantity must be less than or equal to 20.");
        }
    }
}
