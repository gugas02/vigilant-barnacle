namespace Ambev.DeveloperEvaluation.Application.Common;

/// <summary>
/// Command to create a new name in the system.
/// </summary>
public class CreateNameCommand
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