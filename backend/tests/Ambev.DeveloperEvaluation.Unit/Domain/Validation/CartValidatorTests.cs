using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class CartValidatorTests
{
    private readonly CartValidator _validator;

    public CartValidatorTests()
    {
        _validator = new CartValidator();
    }

    [Fact(DisplayName = "Valid cart should pass all validation rules")]
    public void Given_ValidCart_When_Validated_Then_ShouldNotHaveErrors()
    {
        var cart = CartTestData.GenerateValidCart();
        var result = _validator.TestValidate(cart);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Empty products should fail validation")]
    public void Given_EmptyProducts_When_Validated_Then_ShouldHaveError()
    {
        var cart = CartTestData.GenerateValidCart();
        cart.Products = new List<CartItem>();
        var result = _validator.TestValidate(cart);
        result.ShouldHaveValidationErrorFor(x => x.Products);
    }

    [Fact(DisplayName = "Empty UserId should fail validation")]
    public void Given_EmptyUserId_When_Validated_Then_ShouldHaveError()
    {
        var cart = CartTestData.GenerateValidCart();
        cart.UserId = Guid.Empty;
        var result = _validator.TestValidate(cart);
        result.ShouldHaveValidationErrorFor(x => x.UserId);
    }
}
