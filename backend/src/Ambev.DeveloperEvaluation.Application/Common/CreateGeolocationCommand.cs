namespace Ambev.DeveloperEvaluation.Application.Common;

/// <summary>
/// Command to create a new geolocation in the system.
/// </summary>
public class CreateGeolocationCommand
{
    /// <summary>
    /// Gets the geolocation latitude;
    /// Must not be null or empty and should contain latitude.
    /// </summary>
    public string Lat { get; set; } = string.Empty;

    /// <summary>
    /// Gets the geolocation longitude;
    /// Must not be null or empty and should contain longitude.
    /// </summary>
    public string Long { get; set; } = string.Empty;
}