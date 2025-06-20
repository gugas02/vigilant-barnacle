using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItem;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class CreateCartHandlerTests
{
    private readonly ICartRepository _cartRepository = Substitute.For<ICartRepository>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly IProductRepository _productRepository = Substitute.For<IProductRepository>();
    private readonly CreateCartHandler _handler;

    public CreateCartHandlerTests()
    {
        _handler = new CreateCartHandler(_cartRepository, _mapper, _userRepository, _productRepository);
    }

    [Fact(DisplayName = "Should create cart successfully when user and products exist and data is valid")]
    public async Task Handle_ValidRequest_ReturnsCreatedCart()
    {
        var command = new CreateCartCommand
        {
            UserId = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            Products = new List<CreateCartItemCommand> {
                new CreateCartItemCommand { ProductId = Guid.NewGuid(), Quantity = 1 }
            }
        };
        var user = new User { Id = command.UserId };
        var products = new List<Product> { new Product { Id = command.Products[0].ProductId } };
        var cart = CartTestData.GenerateValidCart();
        var createdCart = new Cart { Id = Guid.NewGuid() };
        var result = new CreateCartResult { Id = createdCart.Id, UserId = command.UserId, Date = command.Date, Products = new List<CreateCartItemResult>() };

        _userRepository.GetByIdAsync(command.UserId, Arg.Any<CancellationToken>()).Returns(user);
        _productRepository.GetByIdsAsync(Arg.Any<List<Guid>>(), Arg.Any<CancellationToken>()).Returns(products);
        _mapper.Map<Cart>(command).Returns(cart);
        _cartRepository.CreateAsync(cart, Arg.Any<CancellationToken>()).Returns(createdCart);
        _mapper.Map<CreateCartResult>(createdCart).Returns(result);

        var response = await _handler.Handle(command, CancellationToken.None);
        Assert.Equal(result.Id, response.Id);
        Assert.Equal(result.UserId, response.UserId);
    }

    [Fact(DisplayName = "Should throw ValidationException if user does not exist")]
    public async Task Handle_UserNotFound_ThrowsValidationException()
    {
        var command = new CreateCartCommand { UserId = Guid.NewGuid(), Products = new List<CreateCartItemCommand>() };
        _userRepository.GetByIdAsync(command.UserId, Arg.Any<CancellationToken>()).Returns((User)null!);
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "Should throw ValidationException if no products found")]
    public async Task Handle_ProductsNotFound_ThrowsValidationException()
    {
        var command = new CreateCartCommand { UserId = Guid.NewGuid(), Products = new List<CreateCartItemCommand> { new CreateCartItemCommand { ProductId = Guid.NewGuid(), Quantity = 1 } } };
        var user = new User { Id = command.UserId };
        _userRepository.GetByIdAsync(command.UserId, Arg.Any<CancellationToken>()).Returns(user);
        _productRepository.GetByIdsAsync(Arg.Any<List<Guid>>(), Arg.Any<CancellationToken>()).Returns((List<Product>)null!);
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "Should throw DomainException if cart validation fails")]
    public async Task Handle_InvalidCart_ThrowsDomainException()
    {
        var command = new CreateCartCommand { UserId = Guid.NewGuid(), Products = new List<CreateCartItemCommand> { new CreateCartItemCommand { ProductId = Guid.NewGuid(), Quantity = 1 } } };
        var user = new User { Id = command.UserId };
        var products = new List<Product> { new Product { Id = command.Products[0].ProductId } };
        var cart = new Cart();
        _userRepository.GetByIdAsync(command.UserId, Arg.Any<CancellationToken>()).Returns(user);
        _productRepository.GetByIdsAsync(Arg.Any<List<Guid>>(), Arg.Any<CancellationToken>()).Returns(products);
        _mapper.Map<Cart>(command).Returns(cart);
        await Assert.ThrowsAsync<DomainException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
