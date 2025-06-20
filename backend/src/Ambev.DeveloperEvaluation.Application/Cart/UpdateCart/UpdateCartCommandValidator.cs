using Ambev.DeveloperEvaluation.Application.CartItems.UpdateCartItem;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Validator for UpdateCartCommand that defines validation rules for cart creation command.
/// </summary>
public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
{
    /// <summary>
    /// Initializes a new instance of the UpdateCartCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Title: Required, must be between 3 and 80 characters
    /// - Description: Required, must be between 3 and 250 characters
    /// - Category: Required, must be between 3 and 50 characters
    /// - Image: Required, must be between 3 and 500 characters
    /// - ImPriceage: Required, must be greater or equal to 0.
    /// - Rating: Must meet requirements (using CreateRatingCommandValidator)
    /// </remarks>
    public UpdateCartCommandValidator()
    { 
        RuleFor(user => user.Date)
            .NotEmpty();

        RuleFor(user => user.UserId)
            .NotEmpty();

        RuleFor(user => user.Products)
            .NotEmpty().ForEach(product => product.SetValidator(new UpdateCartItemCommandValidator()));
    }
}