using Ambev.DeveloperEvaluation.Domain.Entities;
using Xunit;
using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class CartTests
    {
        [Fact(DisplayName = "Cart should have default values after instantiation")]
        public void Given_NewCart_When_Instantiated_Then_DefaultValuesShouldBeSet()
        {
            var cart = new Cart();
            Assert.NotNull(cart.Products);
            Assert.NotNull(cart.User);
            Assert.True(cart.CreatedAt <= DateTime.UtcNow);
            Assert.Null(cart.UpdatedAt);
        }

        [Fact(DisplayName = "Update should copy all fields and update UpdatedAt")]
        public void Given_Cart_When_UpdatedWithAnotherCart_Then_FieldsShouldBeCopiedAndUpdatedAtSet()
        {
            var cart = CartTestData.GenerateValidCart();
            var updatedCart = new Cart
            {
                Date = DateTime.UtcNow.AddDays(-1),
                UserId = Guid.NewGuid(),
                User = new User(),
                Products = new List<CartItem> { CartItemTestData.GenerateValidCartItem(), CartItemTestData.GenerateValidCartItem() }
            };
            var before = DateTime.UtcNow;
            cart.Update(updatedCart);
            Assert.Equal(updatedCart.Date, cart.Date);
            Assert.Equal(updatedCart.UserId, cart.UserId);
            Assert.Equal(updatedCart.User, cart.User);
            Assert.NotNull(cart.UpdatedAt);
            Assert.True(cart.UpdatedAt >= before);
        }

        [Fact(DisplayName = "Validation should pass for valid cart data")]
        public void Given_ValidCartData_When_Validated_Then_ShouldReturnValid()
        {
            var cart = CartTestData.GenerateValidCart();
            var result = cart.Validate();
            Assert.True(result.IsValid);
        }
    }
}
