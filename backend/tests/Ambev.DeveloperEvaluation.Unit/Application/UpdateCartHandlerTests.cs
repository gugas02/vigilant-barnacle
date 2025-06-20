using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Application.CartItems.UpdateCartItem;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class UpdateCartHandlerTests
{
    private readonly ICartRepository _cartRepository = Substitute.For<ICartRepository>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly IProductRepository _productRepository = Substitute.For<IProductRepository>();
    private readonly UpdateCartHandler _handler;

    public UpdateCartHandlerTests()
    {
        _handler = new UpdateCartHandler(_cartRepository, _mapper, _userRepository, _productRepository);
    }

    [Fact(DisplayName = "Should update cart successfully when cart, user, and products exist and data is valid")]
    public async Task Handle_ValidRequest_UpdatesCart()
    {
        var cartId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        var command = new UpdateCartCommand
        {
            Id = cartId,
            UserId = userId,
            Date = DateTime.UtcNow,
            Products = new List<UpdateCartItemCommand> {
                new UpdateCartItemCommand { ProductId = productId, Quantity = 2 }
            }
        };
        var existingCart = CartTestData.GenerateValidCart();
        existingCart.Id = cartId;
        var user = UserTestData.GenerateValidUser();
        user.Id = userId;
        var products = new List<Product> { ProductTestData.GenerateValidProduct(productId) };
        var mappedCart = CartTestData.GenerateValidCart();
        mappedCart.User = user;
        mappedCart.Products = existingCart.Products;
        var updateResult = new UpdateCartResult { Id = cartId, UserId = userId, Date = command.Date, Products = new List<UpdateCartItemResult>() };

        _cartRepository.GetByIdAsync(cartId, Arg.Any<CancellationToken>()).Returns(existingCart);
        _userRepository.GetByIdAsync(userId, Arg.Any<CancellationToken>()).Returns(user);
        _productRepository.GetByIdsAsync(Arg.Any<List<Guid>>(), Arg.Any<CancellationToken>()).Returns(products);
        _mapper.Map<Cart>(command).Returns(mappedCart);
        _mapper.Map<UpdateCartResult>(existingCart).Returns(updateResult);
        var response = await _handler.Handle(command, CancellationToken.None);
        Assert.Equal(updateResult.Id, response.Id);
        Assert.Equal(updateResult.UserId, response.UserId);
    }

    [Fact(DisplayName = "Should throw ValidationException if cart does not exist")]
    public async Task Handle_CartNotFound_ThrowsValidationException()
    {
        var command = new UpdateCartCommand { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Products = new List<UpdateCartItemCommand>() };
        _cartRepository.GetByIdAsync(command.Id, Arg.Any<CancellationToken>()).Returns((Cart)null!);
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "Should throw ValidationException if user does not exist")]
    public async Task Handle_UserNotFound_ThrowsValidationException()
    {
        var cartId = Guid.NewGuid();
        var command = new UpdateCartCommand { Id = cartId, UserId = Guid.NewGuid(), Products = new List<UpdateCartItemCommand>() };
        var existingCart = CartTestData.GenerateValidCart();
        existingCart.Id = cartId;
        _cartRepository.GetByIdAsync(cartId, Arg.Any<CancellationToken>()).Returns(existingCart);
        _userRepository.GetByIdAsync(command.UserId, Arg.Any<CancellationToken>()).Returns((User)null!);
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "Should throw ValidationException if products do not exist")]
    public async Task Handle_ProductsNotFound_ThrowsValidationException()
    {
        var cartId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var command = new UpdateCartCommand
        {
            Id = cartId,
            UserId = userId,
            Products = new List<UpdateCartItemCommand> { new UpdateCartItemCommand { ProductId = Guid.NewGuid(), Quantity = 1 } }
        };
        var existingCart = CartTestData.GenerateValidCart();
        existingCart.Id = cartId;
        var user = UserTestData.GenerateValidUser();
        user.Id = userId;
        _cartRepository.GetByIdAsync(cartId, Arg.Any<CancellationToken>()).Returns(existingCart);
        _userRepository.GetByIdAsync(userId, Arg.Any<CancellationToken>()).Returns(user);
        _productRepository.GetByIdsAsync(Arg.Any<List<Guid>>(), Arg.Any<CancellationToken>()).Returns((List<Product>)null!);
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "Should throw DomainException if cart validation fails")]
    public async Task Handle_InvalidCart_ThrowsDomainException()
    {
        var cartId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        var command = new UpdateCartCommand
        {
            Id = cartId,
            UserId = userId,
            Date = DateTime.UtcNow,
            Products = new List<UpdateCartItemCommand> { new UpdateCartItemCommand { ProductId = productId, Quantity = 1 } }
        };
        var existingCart = CartTestData.GenerateValidCart();
        existingCart.Id = cartId;
        var user = UserTestData.GenerateValidUser();
        user.Id = userId;
        var products = new List<Product> { ProductTestData.GenerateValidProduct(productId) };
        var mappedCart = new Cart();
        mappedCart.User = user;
        mappedCart.Products = existingCart.Products;
        _cartRepository.GetByIdAsync(cartId, Arg.Any<CancellationToken>()).Returns(existingCart);
        _userRepository.GetByIdAsync(userId, Arg.Any<CancellationToken>()).Returns(user);
        _productRepository.GetByIdsAsync(Arg.Any<List<Guid>>(), Arg.Any<CancellationToken>()).Returns(products);
        _mapper.Map<Cart>(command).Returns(mappedCart);
        await Assert.ThrowsAsync<DomainException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
