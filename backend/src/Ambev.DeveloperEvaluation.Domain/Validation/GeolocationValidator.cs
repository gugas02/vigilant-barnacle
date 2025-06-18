using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class GeolocationValidator : AbstractValidator<Geolocation>
{
    public GeolocationValidator()
    {
        RuleFor(geolocation => geolocation.Lat)
            .NotEmpty()
            .MinimumLength(2).WithMessage("Lat must be at least 3 characters long.")
            .MaximumLength(12).WithMessage("Lat cannot be longer than 12 characters.");

        RuleFor(geolocation => geolocation.Long)
            .NotEmpty()
            .MinimumLength(2).WithMessage("Long must be at least 3 characters long.")
            .MaximumLength(13).WithMessage("Long cannot be longer than 13 characters.");
    }
}
