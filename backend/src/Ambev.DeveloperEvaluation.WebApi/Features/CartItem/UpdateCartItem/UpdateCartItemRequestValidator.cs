using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.UpdateCartItem;

/// <summary>
/// Validator for UpdateCartItemRequest that defines validation rules for cartItem creation.
/// </summary>
public class UpdateCartItemRequestValidator : AbstractValidator<UpdateCartItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateCartItemRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Quantity: Required, must be not null and not empty
    /// - ProductId: Required, must be greater or equal to 0.
    /// </remarks>
    public UpdateCartItemRequestValidator()
    {
        RuleFor(user => user.ProductId)
            .NotEmpty();

        RuleFor(user => user.Quantity)
            .GreaterThan(0).WithMessage("Rate must be greater than 0.");
    }
}