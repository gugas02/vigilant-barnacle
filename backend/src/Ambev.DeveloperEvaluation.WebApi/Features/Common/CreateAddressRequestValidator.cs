using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Common;

/// <summary>
/// Validator for CreateAddressRequest that defines validation rules for user creation.
/// </summary>
public class CreateAddressRequestValidator : AbstractValidator<CreateAddressRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateAddressRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - City: Required, length between 2 and 70 characters
    /// - Street: Required, length between 2 and 50 characters
    /// - Number: Required, length between 2 and 20 characters
    /// - Zipcode: Required, length between 2 and 16 characters
    /// - Geolocation: Must meet security requirements (using CreateGeolocationRequestValidator)
    /// </remarks>
    public CreateAddressRequestValidator()
    {
        RuleFor(user => user.City).NotEmpty().Length(2, 70);
        RuleFor(user => user.Street).NotEmpty().Length(2, 50);
        RuleFor(user => user.Number).NotEmpty().Length(2, 20);
        RuleFor(user => user.Zipcode).NotEmpty().Length(2, 16);

        RuleFor(user => user.Geolocation).SetValidator(new CreateGeolocationRequestValidator());
    }
}