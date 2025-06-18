using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(address => address.City)
            .NotEmpty()
            .MinimumLength(2).WithMessage("City must be at least 3 characters long.")
            .MaximumLength(70).WithMessage("City cannot be longer than 70 characters.");

        RuleFor(address => address.Street)
            .NotEmpty()
            .MinimumLength(2).WithMessage("Street must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Street cannot be longer than 50 characters.");

        RuleFor(address => address.Number)
            .NotEmpty()
            .MinimumLength(2).WithMessage("Number must be at least 3 characters long.")
            .MaximumLength(20).WithMessage("Number cannot be longer than 20 characters.");

        RuleFor(address => address.Zipcode)
            .NotEmpty()
            .MinimumLength(2).WithMessage("Zipcode must be at least 3 characters long.")
            .MaximumLength(16).WithMessage("Zipcode cannot be longer than 16 characters.");
            
        RuleFor(address => address.Geolocation).SetValidator(new GeolocationValidator());
    }
}
