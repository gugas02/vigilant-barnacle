using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Common;

/// <summary>
/// Validator for CreateGeolocationCommand that defines validation rules for geolocation creation.
/// </summary>
public class CreateGeolocationCommandValidator : AbstractValidator<CreateGeolocationCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateGeolocationCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Lat: Required, length between 2 and 12 characters
    /// - Long: Required, length between 2 and 13 characters
    /// </remarks>
    public CreateGeolocationCommandValidator()
    {
        RuleFor(user => user.Lat).NotEmpty().Length(2, 12);
        RuleFor(user => user.Long).NotEmpty().Length(2, 13);
    }
}