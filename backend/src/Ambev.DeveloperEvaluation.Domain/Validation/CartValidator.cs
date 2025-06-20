using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartValidator : AbstractValidator<Cart>
{
    public CartValidator()
    {
        RuleFor(user => user.Date)
            .NotEmpty();

        RuleFor(user => user.UserId)
            .NotEmpty();

        RuleFor(user => user.Products)
            .NotEmpty().ForEach(product => product.SetValidator(new CartItemValidator()));
    }
}
