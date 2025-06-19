using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Common;

/// <summary>
/// Validator for CreateRatingCommand that defines validation rules for name creation.
/// </summary>
public class CreateRatingCommandValidator : AbstractValidator<CreateRatingCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateRatingCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Rate: Required and between 0 and 5
    /// - Count: Required and greater or equal to 0
    /// </remarks>
    public CreateRatingCommandValidator()
    {
        RuleFor(user => user.Rate).NotNull().InclusiveBetween(0,5);
        RuleFor(user => user.Count).NotNull().GreaterThanOrEqualTo(0);
    }
}