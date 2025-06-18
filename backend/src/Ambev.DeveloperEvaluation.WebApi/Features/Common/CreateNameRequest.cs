using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Common;

/// <summary>
/// Represents a request to create a new name in the system.
/// </summary>
public class CreateNameRequest
{
    /// <summary>
    /// Gets the name's first name.
    /// Must not be null or empty and should contain first name only.
    /// </summary>
    public string Firstname { get; set; } = string.Empty;

    /// <summary>
    /// Gets the name's Last name.
    /// Must not be null or empty and should contain last name only.
    /// </summary>
    public string Lastname { get; set; } = string.Empty;
}