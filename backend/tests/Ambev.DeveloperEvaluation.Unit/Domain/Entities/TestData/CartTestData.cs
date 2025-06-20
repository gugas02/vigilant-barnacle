using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class CartTestData
    {
        private static readonly Faker<Cart> CartFaker = new Faker<Cart>()
            .RuleFor(c => c.Date, f => f.Date.Past())
            .RuleFor(c => c.UserId, f => Guid.NewGuid())
            .RuleFor(c => c.User, f => UserTestData.GenerateValidUser())
            .RuleFor(c => c.Products, f => new List<CartItem> { CartItemTestData.GenerateValidCartItem() })
            .RuleFor(c => c.CreatedAt, f => f.Date.Past());

        public static Cart GenerateValidCart()
        {
            return CartFaker.Generate();
        }
    }
}
