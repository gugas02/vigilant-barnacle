using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using NSubstitute;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class GetUserHandlerTests
{
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();
    private readonly GetUserHandler _handler;

    public GetUserHandlerTests()
    {
        _handler = new GetUserHandler(_userRepository, _mapper);
    }

    [Fact(DisplayName = "Should return user details when user exists")]
    public async Task Handle_ValidRequest_ReturnsUserDetails()
    {
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, Username = "user1", Email = "user1@email.com" };
        var command = new GetUserCommand(userId);
        var expectedResult = new GetUserResult { Id = userId, Username = user.Username, Email = user.Email };
        _userRepository.GetByIdAsync(userId, Arg.Any<CancellationToken>()).Returns(user);
        _mapper.Map<GetUserResult>(user).Returns(expectedResult);
        var response = await _handler.Handle(command, CancellationToken.None);
        Assert.Equal(expectedResult.Id, response.Id);
        Assert.Equal(expectedResult.Username, response.Username);
        Assert.Equal(expectedResult.Email, response.Email);
    }

    [Fact(DisplayName = "Should throw KeyNotFoundException if user does not exist")]
    public async Task Handle_UserNotFound_ThrowsKeyNotFoundException()
    {
        var userId = Guid.NewGuid();
        var command = new GetUserCommand(userId);
        _userRepository.GetByIdAsync(userId, Arg.Any<CancellationToken>()).Returns((User)null!);
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
