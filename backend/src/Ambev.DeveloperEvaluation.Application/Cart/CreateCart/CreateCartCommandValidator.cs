using Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItem;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Validator for CreateCartCommand that defines validation rules for cart creation command.
/// </summary>
public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Date: Required, must be not null and not empty
    /// - UserId: Required, must be not null and not empty
    /// - Products: Must meet requirements (using CreateCartItemCommandValidator)
    /// </remarks>
    public CreateCartCommandValidator()
    { 
        RuleFor(user => user.Date)
            .NotEmpty();

        RuleFor(user => user.UserId)
            .NotEmpty();

        RuleFor(user => user.Products)
            .NotEmpty().ForEach(product => product.SetValidator(new CreateCartItemCommandValidator()));
    }
}
