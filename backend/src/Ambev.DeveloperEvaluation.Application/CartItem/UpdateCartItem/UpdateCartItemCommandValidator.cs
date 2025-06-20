using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartItems.UpdateCartItem;

/// <summary>
/// Validator for UpdateCartItemCommand that defines validation rules for cartItem creation command.
/// </summary>
public class UpdateCartItemCommandValidator : AbstractValidator<UpdateCartItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the UpdateCartItemCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Quantity: Required, must be between not null and not empty
    /// - ProductId: Required, must be greater or equal to 0.
    /// </remarks>
    public UpdateCartItemCommandValidator()
    {
        RuleFor(user => user.ProductId)
            .NotEmpty();

        RuleFor(user => user.Quantity)
            .GreaterThan(0).WithMessage("Rate must be greater than 0.")
            .LessThanOrEqualTo(20).WithMessage("Quantity must be lower or equal to 20.");
    }
}