using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUsers;

/// <summary>
/// Response model for GetUsers operation
/// </summary>
public class GetUsersResult
{
    /// <summary>
    /// The unique identifier of the user
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The user's full name
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The user's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The user's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;   

    /// <summary>
    /// The user's fullname.
    /// </summary>
    public CreateNameCommand Name { get; set; }

    /// <summary>
    /// The user's Address.
    /// </summary>
    public CreateAddressCommand Address { get; set; }

    /// <summary>
    /// The user's role in the system
    /// </summary>
    public EUserRole Role { get; set; }

    /// <summary>
    /// The current status of the user
    /// </summary>
    public EUserStatus Status { get; set; }
}
