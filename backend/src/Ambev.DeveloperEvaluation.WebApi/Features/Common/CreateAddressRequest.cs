using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Common;

/// <summary>
/// Represents a request to create a new address in the system.
/// </summary>
public class CreateAddressRequest
{
    /// <summary>
    /// Gets the user's city name.
    /// Must not be null or empty and should contain city name.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gets the user's street name.
    /// Must not be null or empty and should contain street name only.
    /// </summary>
    public string Street { get; set; } = string.Empty;

    /// <summary>
    /// Gets the user's number.
    /// Must not be null or empty and should contain Addres number.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets the user's zipcode.
    /// Must not be null or empty and should contain Addres zipcode.
    /// </summary>
    public string Zipcode { get; set; } = string.Empty;

    /// <summary>
    /// Gets the user's geolocation.
    /// Must not be null or empty and should contain Addres geolocation.
    /// </summary>
    public CreateGeolocationRequest Geolocation { get; set; }
}