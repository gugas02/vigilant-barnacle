using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Common;

/// <summary>
/// Validator for CreateAddressCommand that defines validation rules for address creation.
/// </summary>
public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateAddressCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - City: Required, length between 2 and 70 characters
    /// - Street: Required, length between 2 and 50 characters
    /// - Number: Required, length between 2 and 20 characters
    /// - Zipcode: Required, length between 2 and 16 characters
    /// - Geolocation: Must meet security requirements (using CreateGeolocationCommandValidator)
    /// </remarks>
    public CreateAddressCommandValidator()
    {
        RuleFor(user => user.City).NotEmpty().Length(2, 70);
        RuleFor(user => user.Street).NotEmpty().Length(2, 50);
        RuleFor(user => user.Number).NotEmpty().Length(2, 20);
        RuleFor(user => user.Zipcode).NotEmpty().Length(2, 16);

        RuleFor(user => user.Geolocation).SetValidator(new CreateGeolocationCommandValidator());
    }
}