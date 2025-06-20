using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the User entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class UserTests
{
    /// <summary>
    /// Tests that validation passes when all user properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid user data")]
    public void Given_ValidUserData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();

        // Act
        var result = user.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when user properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid user data")]
    public void Given_InvalidUserData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var user = new User
        {
            Username = "", // Invalid: empty
            Password = UserTestData.GenerateInvalidPassword(), // Invalid: doesn't meet password requirements
            Email = UserTestData.GenerateInvalidEmail(), // Invalid: not a valid email
            Phone = UserTestData.GenerateInvalidPhone(), // Invalid: doesn't match pattern
            Status = EUserStatus.Unknown, // Invalid: cannot be Unknown
            Role = EUserRole.None // Invalid: cannot be None
        };

        // Act
        var result = user.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that a new user has default property values set.
    /// </summary>
    [Fact(DisplayName = "User should have default values after instantiation")]
    public void Given_NewUser_When_Instantiated_Then_DefaultValuesShouldBeSet()
    {
        // Act
        var user = new User();

        // Assert
        Assert.Equal(string.Empty, user.Email);
        Assert.Equal(string.Empty, user.Username);
        Assert.Equal(string.Empty, user.Password);
        Assert.Null(user.Name);
        Assert.Null(user.Address);
        Assert.Equal(string.Empty, user.Phone);
        Assert.Equal(default(EUserStatus), user.Status);
        Assert.Equal(default(EUserRole), user.Role);
        Assert.True(user.CreatedAt <= DateTime.UtcNow);
        Assert.Null(user.UpdatedAt);
    }

    /// <summary>
    /// Tests that updating a user with another user's data copies all fields and updates UpdatedAt.
    /// </summary>
    [Fact(DisplayName = "Update should copy all fields and update UpdatedAt")]
    public void Given_User_When_UpdatedWithAnotherUser_Then_FieldsShouldBeCopiedAndUpdatedAtSet()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        var updatedUser = UserTestData.GenerateAnotherValidUser();
        var before = DateTime.UtcNow;

        // Act
        user.Update(updatedUser);

        // Assert
        Assert.Equal(updatedUser.Email, user.Email);
        Assert.Equal(updatedUser.Username, user.Username);
        Assert.Equal(updatedUser.Name, user.Name);
        Assert.Equal(updatedUser.Address, user.Address);
        Assert.Equal(updatedUser.Phone, user.Phone);
        Assert.Equal(updatedUser.Status, user.Status);
        Assert.Equal(updatedUser.Role, user.Role);
        Assert.NotNull(user.UpdatedAt);
        Assert.True(user.UpdatedAt >= before);
    }

    /// <summary>
    /// Tests that the IUser interface properties return the correct values from the User entity.
    /// </summary>
    [Fact(DisplayName = "IUser interface properties should return correct values")]
    public void Given_User_When_AccessingIUserProperties_Then_ShouldReturnCorrectValues()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        var iUser = (IUser)user;

        // Assert
        Assert.Equal(user.Id.ToString(), iUser.Id);
        Assert.Equal(user.Username, iUser.Username);
        Assert.Equal(user.Role.ToString(), iUser.Role);
    }
}
