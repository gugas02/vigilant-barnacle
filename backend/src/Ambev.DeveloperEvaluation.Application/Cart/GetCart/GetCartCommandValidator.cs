using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Validator for GetCartCommand
/// </summary>
public class GetCartCommandValidator : AbstractValidator<GetCartCommand>
{
    /// <summary>
    /// Initializes validation rules for GetCartCommand
    /// </summary>
    public GetCartCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart ID is required");
    }
}
