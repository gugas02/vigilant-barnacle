using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for product creation command.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Title: Required, must be between 3 and 80 characters
    /// - Description: Required, must be between 3 and 250 characters
    /// - Category: Required, must be between 3 and 50 characters
    /// - Image: Required, must be between 3 and 500 characters
    /// - ImPriceage: Required, must be greater or equal to 0.
    /// - Rating: Must meet requirements (using CreateRatingCommandValidator)
    /// </remarks>
    public CreateProductCommandValidator()
    {
        RuleFor(user => user.Title).NotEmpty().Length(3, 80);
        RuleFor(user => user.Description).NotEmpty().Length(3, 250);
        RuleFor(user => user.Category).NotEmpty().Length(3, 50);
        RuleFor(user => user.Image).NotEmpty().Length(3, 500);
        RuleFor(name => name.Price).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(user => user.Rating).SetValidator(new CreateRatingCommandValidator());
    }
}
