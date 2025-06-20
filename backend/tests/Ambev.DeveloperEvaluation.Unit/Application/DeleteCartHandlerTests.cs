using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class DeleteCartHandlerTests
{
    private readonly ICartRepository _cartRepository = Substitute.For<ICartRepository>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();
    private readonly DeleteCartHandler _handler;

    public DeleteCartHandlerTests()
    {
        _handler = new DeleteCartHandler(_cartRepository, _mapper);
    }

    [Fact(DisplayName = "Should delete cart successfully when cart exists")]
    public async Task Handle_ValidRequest_DeletesCartAndReturnsResult()
    {
        var cartId = Guid.NewGuid();
        var cart = new Cart { Id = cartId };
        var command = new DeleteCartCommand(cartId);
        _cartRepository.GetByIdAsync(cartId, Arg.Any<CancellationToken>()).Returns(cart);
        DeleteCartResult? result = null;
        _cartRepository.When(r => r.Delete(cart, Arg.Any<CancellationToken>())).Do(_ => result = new DeleteCartResult("Cart succesfully deleted."));
        var response = await _handler.Handle(command, CancellationToken.None);
        Assert.Equal("Cart succesfully deleted.", response.Message);
    }

    [Fact(DisplayName = "Should throw KeyNotFoundException if cart does not exist")]
    public async Task Handle_CartNotFound_ThrowsKeyNotFoundException()
    {
        var cartId = Guid.NewGuid();
        var command = new DeleteCartCommand(cartId);
        _cartRepository.GetByIdAsync(cartId, Arg.Any<CancellationToken>()).Returns((Cart)null!);
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
