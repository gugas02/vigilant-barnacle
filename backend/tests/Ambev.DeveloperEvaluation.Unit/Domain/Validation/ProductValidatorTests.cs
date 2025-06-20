using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class ProductValidatorTests
{
    private readonly ProductValidator _validator;

    public ProductValidatorTests()
    {
        _validator = new ProductValidator();
    }

    [Fact(DisplayName = "Valid product should pass all validation rules")]
    public void Given_ValidProduct_When_Validated_Then_ShouldNotHaveErrors()
    {
        var product = ProductTestData.GenerateValidProduct();
        var result = _validator.TestValidate(product);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Empty title should fail validation")]
    public void Given_EmptyTitle_When_Validated_Then_ShouldHaveError()
    {
        var product = ProductTestData.GenerateValidProduct();
        product.Title = string.Empty;
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    [Fact(DisplayName = "Free price should fail validation")]
    public void Given_FreePrice_When_Validated_Then_ShouldHaveError()
    {
        var product = ProductTestData.GenerateValidProduct();
        product.Price = 0;
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(x => x.Price);
    }

    [Fact(DisplayName = "Empty description should fail validation")]
    public void Given_EmptyDescription_When_Validated_Then_ShouldHaveError()
    {
        var product = ProductTestData.GenerateValidProduct();
        product.Description = string.Empty;
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    [Fact(DisplayName = "Empty category should fail validation")]
    public void Given_EmptyCategory_When_Validated_Then_ShouldHaveError()
    {
        var product = ProductTestData.GenerateValidProduct();
        product.Category = string.Empty;
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(x => x.Category);
    }

    [Fact(DisplayName = "Empty image should fail validation")]
    public void Given_EmptyImage_When_Validated_Then_ShouldHaveError()
    {
        var product = ProductTestData.GenerateValidProduct();
        product.Image = string.Empty;
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(x => x.Image);
    }
}
