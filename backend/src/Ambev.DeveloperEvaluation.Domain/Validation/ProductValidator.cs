using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(user => user.Title)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
            .MaximumLength(80).WithMessage("Title cannot be longer than 80 characters.");
        
        RuleFor(user => user.Description)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Description must be at least 3 characters long.")
            .MaximumLength(250).WithMessage("Description cannot be longer than 250 characters.");
        
        RuleFor(user => user.Category)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Category must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Category cannot be longer than 50 characters.");
        
        RuleFor(user => user.Image)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Image must be at least 3 characters long.")
            .MaximumLength(500).WithMessage("Image cannot be longer than 50 characters.");

        RuleFor(name => name.Price)
            .NotNull()
            .GreaterThan(0).WithMessage("Rate must be greater than 0.");

        RuleFor(user => user.Rating).SetValidator(new RatingValidator());
    }
}
