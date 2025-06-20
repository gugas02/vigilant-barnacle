using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using NSubstitute;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class AuthenticateUserHandlerTests
{
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly IPasswordHasher _passwordHasher = Substitute.For<IPasswordHasher>();
    private readonly IJwtTokenGenerator _jwtTokenGenerator = Substitute.For<IJwtTokenGenerator>();
    private readonly AuthenticateUserHandler _handler;

    public AuthenticateUserHandlerTests()
    {
        _handler = new AuthenticateUserHandler(_userRepository, _passwordHasher, _jwtTokenGenerator);
    }

    [Fact(DisplayName = "Should return token and role for valid credentials and active user")]
    public async Task Handle_ValidCredentials_ActiveUser_ReturnsTokenAndRole()
    {
        var command = new AuthenticateUserCommand { Username = "user", Password = "pass" };
        var user = new User { Username = "user", Password = "hashed", Status = EUserStatus.Active, Role = EUserRole.Admin };
        _userRepository.GetByUsernameAsync(command.Username, Arg.Any<CancellationToken>()).Returns(user);
        _passwordHasher.VerifyPassword(command.Password, user.Password).Returns(true);
        _jwtTokenGenerator.GenerateToken(user).Returns("jwt-token");
        var result = await _handler.Handle(command, CancellationToken.None);
        Assert.Equal("jwt-token", result.Token);
        Assert.Equal(EUserRole.Admin, result.Role);
    }

    [Fact(DisplayName = "Should throw UnauthorizedAccessException for invalid credentials")]
    public async Task Handle_InvalidCredentials_ThrowsUnauthorized()
    {
        var command = new AuthenticateUserCommand { Username = "user", Password = "wrong" };
        var user = new User { Username = "user", Password = "hashed", Status = EUserStatus.Active };
        _userRepository.GetByUsernameAsync(command.Username, Arg.Any<CancellationToken>()).Returns(user);
        _passwordHasher.VerifyPassword(command.Password, user.Password).Returns(false);
        await Assert.ThrowsAsync<UnauthorizedAccessException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "Should throw UnauthorizedAccessException if user not found")]
    public async Task Handle_UserNotFound_ThrowsUnauthorized()
    {
        var command = new AuthenticateUserCommand { Username = "notfound", Password = "pass" };
        _userRepository.GetByUsernameAsync(command.Username, Arg.Any<CancellationToken>()).Returns((User)null);
        await Assert.ThrowsAsync<UnauthorizedAccessException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "Should throw UnauthorizedAccessException if user is not active")]
    public async Task Handle_UserNotActive_ThrowsUnauthorized()
    {
        var command = new AuthenticateUserCommand { Username = "user", Password = "pass" };
        var user = new User { Username = "user", Password = "hashed", Status = EUserStatus.Suspended };
        _userRepository.GetByUsernameAsync(command.Username, Arg.Any<CancellationToken>()).Returns(user);
        _passwordHasher.VerifyPassword(command.Password, user.Password).Returns(true);
        await Assert.ThrowsAsync<UnauthorizedAccessException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
