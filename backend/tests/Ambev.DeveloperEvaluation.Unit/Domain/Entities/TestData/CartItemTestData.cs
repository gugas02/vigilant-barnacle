using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using System;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class CartItemTestData
    {
        private static readonly Faker<CartItem> CartItemFaker = new Faker<CartItem>()
            .RuleFor(ci => ci.CartId, f => Guid.NewGuid())
            .RuleFor(ci => ci.ProductId, f => Guid.NewGuid())
            .RuleFor(ci => ci.Quantity, f => f.Random.Int(1, 20))
            .RuleFor(ci => ci.CreatedAt, f => f.Date.Past());

        public static CartItem GenerateValidCartItem()
        {
            var cart = CartItemFaker.Generate();
            cart.Product = ProductTestData.GenerateValidProduct(cart.ProductId);
            return cart;
        }
    }
}
