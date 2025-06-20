using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.UpdateCartItem;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// Validator for UpdateCartRequest that defines validation rules for cart creation.
/// </summary>
public class UpdateCartRequestValidator : AbstractValidator<UpdateCartRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateCartRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Date: Required, must be not null and not empty
    /// - UserId: Required, must be not null and not empty
    /// - Products: Must meet requirements (using UpdateCartItemRequestValidator)
    /// </remarks>
    public UpdateCartRequestValidator()
    {
        RuleFor(user => user.Date)
            .NotEmpty();

        RuleFor(user => user.UserId)
            .NotEmpty();

        RuleFor(user => user.Products)
            .NotEmpty().ForEach(product => product.SetValidator(new UpdateCartItemRequestValidator()));
    }
}