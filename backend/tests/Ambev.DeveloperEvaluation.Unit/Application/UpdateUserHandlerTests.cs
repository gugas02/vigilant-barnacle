using Ambev.DeveloperEvaluation.Application.Users.UpdateUser;
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
using Ambev.DeveloperEvaluation.Unit.Domain.ValueObjects.TestData;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class UpdateUserHandlerTests
{
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();
    private readonly IPasswordHasher _passwordHasher = Substitute.For<IPasswordHasher>();
    private readonly UpdateUserHandler _handler;

    public UpdateUserHandlerTests()
    {
        _handler = new UpdateUserHandler(_userRepository, _mapper, _passwordHasher);
    }

    [Fact(DisplayName = "Should update user successfully when user exists and data is valid")]
    public async Task Handle_ValidRequest_UpdatesUser()
    {
        var userId = Guid.NewGuid();
        var command = new UpdateUserCommand
        {
            Id = userId,
            Username = "updateduser",
            Password = "NewPassword@123",
            Phone = "+5511999999999",
            Email = "updated@email.com",
            Name = new Ambev.DeveloperEvaluation.Application.Common.CreateNameCommand { Firstname = "John", Lastname = "Doe" },
            Address = new Ambev.DeveloperEvaluation.Application.Common.CreateAddressCommand { City = "Sample City", Street = "Sample Street", Number = "123", Zipcode = "12345-678", Geolocation = new Ambev.DeveloperEvaluation.Application.Common.CreateGeolocationCommand { Lat = "-23.5505", Long = "-46.6333" } },
            Status = Ambev.DeveloperEvaluation.Domain.Enums.EUserStatus.Active,
            Role = Ambev.DeveloperEvaluation.Domain.Enums.EUserRole.Customer
        };
        var existingUser = UserTestData.GenerateValidUser();
        existingUser.Id = userId;
        var mappedUser = UserTestData.GenerateValidUser();
        mappedUser.Username = command.Username;
        mappedUser.Password = command.Password;
        mappedUser.Phone = command.Phone;
        mappedUser.Email = command.Email;
        mappedUser.Status = command.Status;
        mappedUser.Role = command.Role;
        var updateResult = new UpdateUserResult
        {
            Id = userId,
            Username = command.Username,
            Password = command.Password,
            Phone = command.Phone,
            Email = command.Email,
            Name = command.Name,
            Address = command.Address,
            Status = command.Status,
            Role = command.Role
        };
        _userRepository.GetByIdAsync(userId, Arg.Any<CancellationToken>()).Returns(existingUser);
        _mapper.Map<User>(command).Returns(mappedUser);
        _mapper.Map<UpdateUserResult>(existingUser).Returns(updateResult);
        _passwordHasher.HashPassword(command.Password).Returns("hashedPassword");
        var response = await _handler.Handle(command, CancellationToken.None);
        Assert.Equal(updateResult.Id, response.Id);
        Assert.Equal(updateResult.Username, response.Username);
        Assert.Equal("hashedPassword", existingUser.Password);
    }

    [Fact(DisplayName = "Should throw ValidationException if user does not exist")]
    public async Task Handle_UserNotFound_ThrowsValidationException()
    {
        var command = new UpdateUserCommand { Id = Guid.NewGuid() };
        _userRepository.GetByIdAsync(command.Id, Arg.Any<CancellationToken>()).Returns((User)null!);
        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact(DisplayName = "Should throw DomainException if user validation fails")]
    public async Task Handle_InvalidUser_ThrowsDomainException()
    {
        var userId = Guid.NewGuid();
        var command = new UpdateUserCommand { Id = userId, Username = "Bad", Password = "bad", Phone = "", Email = "", Name = new Ambev.DeveloperEvaluation.Application.Common.CreateNameCommand(), Address = new Ambev.DeveloperEvaluation.Application.Common.CreateAddressCommand(), Status = Ambev.DeveloperEvaluation.Domain.Enums.EUserStatus.Unknown, Role = Ambev.DeveloperEvaluation.Domain.Enums.EUserRole.None };
        var existingUser = UserTestData.GenerateValidUser();
        existingUser.Id = userId;
        var mappedUser = new User();
        _userRepository.GetByIdAsync(userId, Arg.Any<CancellationToken>()).Returns(existingUser);
        _mapper.Map<User>(command).Returns(mappedUser);
        await Assert.ThrowsAsync<DomainException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
