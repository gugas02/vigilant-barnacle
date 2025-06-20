using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.Unit.Domain.ValueObjects.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class RatingValidatorTests
{
    private readonly RatingValidator _validator;

    public RatingValidatorTests()
    {
        _validator = new RatingValidator();
    }

    [Fact(DisplayName = "Valid rating should pass all validation rules")]
    public void Given_ValidRating_When_Validated_Then_ShouldNotHaveErrors()
    {
        var rating = RatingTestData.GenerateValidRating();
        var result = _validator.TestValidate(rating);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Negative rate should fail validation")]
    public void Given_NegativeRate_When_Validated_Then_ShouldHaveError()
    {
        var rating = RatingTestData.GenerateValidRating();
        rating.Rate = -1;
        var result = _validator.TestValidate(rating);
        result.ShouldHaveValidationErrorFor(x => x.Rate);
    }

    [Fact(DisplayName = "Negative count should fail validation")]
    public void Given_NegativeCount_When_Validated_Then_ShouldHaveError()
    {
        var rating = RatingTestData.GenerateValidRating();
        rating.Count = -1;
        var result = _validator.TestValidate(rating);
        result.ShouldHaveValidationErrorFor(x => x.Count);
    }
}
