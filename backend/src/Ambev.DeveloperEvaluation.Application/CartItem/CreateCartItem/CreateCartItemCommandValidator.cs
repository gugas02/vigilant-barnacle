using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItem;

/// <summary>
/// Validator for CreateCartItemCommand that defines validation rules for cartItem creation command.
/// </summary>
public class CreateCartItemCommandValidator : AbstractValidator<CreateCartItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartItemCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Quantity: Required, must be not null and not empty
    /// - ProductId: Required, must be greater or equal to 0.
    /// </remarks>
    public CreateCartItemCommandValidator()
    {
        RuleFor(user => user.ProductId)
            .NotEmpty();

        RuleFor(user => user.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
            .LessThanOrEqualTo(20).WithMessage("Quantity must be lower or equal to 20.");
    }
}
