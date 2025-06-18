namespace Ambev.DeveloperEvaluation.Application.Common;

/// <summary>
/// Command for creating a new address 
/// </summary>
public class CreateAddressCommand
{
    /// <summary>
    /// Gets the address's city name.
    /// Must not be null or empty and should contain city name.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gets the address's street name.
    /// Must not be null or empty and should contain street name only.
    /// </summary>
    public string Street { get; set; } = string.Empty;

    /// <summary>
    /// Gets the address's number.
    /// Must not be null or empty and should contain Addres number.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets the address's zipcode.
    /// Must not be null or empty and should contain Addres zipcode.
    /// </summary>
    public string Zipcode { get; set; } = string.Empty;

    /// <summary>
    /// Gets the address's geolocation.
    /// Must not be null or empty and should contain Addres geolocation.
    /// </summary>
    public CreateGeolocationCommand Geolocation { get; set; }
}