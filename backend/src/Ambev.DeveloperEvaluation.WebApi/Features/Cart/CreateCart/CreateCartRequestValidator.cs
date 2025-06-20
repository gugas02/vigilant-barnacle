using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.CreateCartItem;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Validator for CreateCartRequest that defines validation rules for cart creation.
/// </summary>
public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Date: Required, must be not null and not empty
    /// - UserId: Required, must be not null and not empty
    /// - Products: Must meet requirements (using CreateCartItemRequestValidator)
    /// </remarks>
    public CreateCartRequestValidator()
    { 
        RuleFor(user => user.Date)
            .NotEmpty();

        RuleFor(user => user.UserId)
            .NotEmpty();

        RuleFor(user => user.Products)
            .NotEmpty().ForEach(product => product.SetValidator(new CreateCartItemRequestValidator()));
    }
}