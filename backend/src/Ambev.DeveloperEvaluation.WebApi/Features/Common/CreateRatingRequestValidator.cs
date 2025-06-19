using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Common;

/// <summary>
/// Validator for CreateRatingRequest that defines validation rules for user creation.
/// </summary>
public class CreateRatingRequestValidator : AbstractValidator<CreateRatingRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateRatingRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Rate: Required and between 0 and 5
    /// - Count: Required and greater or equal to 0
    /// </remarks>
    public CreateRatingRequestValidator()
    {
        RuleFor(user => user.Rate).NotNull().InclusiveBetween(0,5);
        RuleFor(user => user.Count).NotNull().GreaterThanOrEqualTo(0);
    }
}