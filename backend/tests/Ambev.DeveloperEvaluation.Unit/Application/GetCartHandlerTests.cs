using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
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

public class GetCartHandlerTests
{
    private readonly ICartRepository _cartRepository = Substitute.For<ICartRepository>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();
    private readonly GetCartHandler _handler;

    public GetCartHandlerTests()
    {
        _handler = new GetCartHandler(_cartRepository, _mapper);
    }

    [Fact(DisplayName = "Should return cart details when cart exists")]
    public async Task Handle_ValidRequest_ReturnsCartDetails()
    {
        var cartId = Guid.NewGuid();
        var cart = new Cart { Id = cartId };
        var command = new GetCartCommand(cartId);
        var expectedResult = new GetCartResult { Id = cartId };
        _cartRepository.GetByIdAsync(cartId, Arg.Any<CancellationToken>()).Returns(cart);
        _mapper.Map<GetCartResult>(cart).Returns(expectedResult);
        var response = await _handler.Handle(command, CancellationToken.None);
        Assert.Equal(expectedResult.Id, response.Id);
    }

    [Fact(DisplayName = "Should throw KeyNotFoundException if cart does not exist")]
    public async Task Handle_CartNotFound_ThrowsKeyNotFoundException()
    {
        var cartId = Guid.NewGuid();
        var command = new GetCartCommand(cartId);
        _cartRepository.GetByIdAsync(cartId, Arg.Any<CancellationToken>()).Returns((Cart)null!);
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
