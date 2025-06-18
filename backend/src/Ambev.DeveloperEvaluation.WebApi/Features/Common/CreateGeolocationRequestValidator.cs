using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Common;

/// <summary>
/// Validator for CreateGeolocationRequest that defines validation rules for user creation.
/// </summary>
public class CreateGeolocationRequestValidator : AbstractValidator<CreateGeolocationRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateGeolocationRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Lat: Required, length between 2 and 12 characters
    /// - Lat: Required, length between 2 and 13 characters
    /// </remarks>
    public CreateGeolocationRequestValidator()
    {
        RuleFor(user => user.Lat).NotEmpty().Length(2, 12);
        RuleFor(user => user.Long).NotEmpty().Length(2, 13);
    }
}