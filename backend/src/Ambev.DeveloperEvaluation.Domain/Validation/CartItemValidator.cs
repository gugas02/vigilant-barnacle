using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartItemValidator : AbstractValidator<CartItem>
{
    public CartItemValidator()
    {
        RuleFor(user => user.ProductId)
            .NotEmpty();

        RuleFor(user => user.Quantity)
            .GreaterThan(0).WithMessage("Rate must be greater than 0.");

        RuleFor(user => user.Product.Id)
            .Equal(user => user.ProductId).WithMessage(x => $"Product with Id {x.ProductId} not found");
    }
}
