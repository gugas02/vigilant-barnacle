using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

/// <summary>
/// API response model for GetUser operation
/// </summary>
public class GetUserResponse : ApiResponse
{
    /// <summary>
    /// The unique identifier of the newly created user.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The username. Must be unique and contain only valid characters.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The password. Must meet security requirements.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// The phone number in format (XX) XXXXX-XXXX.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// The email address. Must be a valid email format.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The user's fullname.
    /// </summary>
    public CreateNameRequest Name { get; set; }

    /// <summary>
    /// The user's Address.
    /// </summary>
    public CreateAddressRequest Address { get; set; }

    /// <summary>
    /// The initial status of the user account.
    /// </summary>
    public EUserStatus Status { get; set; }

    /// <summary>
    /// The role assigned to the user.
    /// </summary>
    public EUserRole Role { get; set; }
}
