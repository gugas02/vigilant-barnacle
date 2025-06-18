using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public class Address: BaseValueObject
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
    public Geolocation Geolocation { get; set; }

    public Address()
    {
        Geolocation = new Geolocation();
    }
    /// <summary>
    /// Initializes a new instance of the Address class.
    /// </summary>
    public Address(string city, string street, string number, string zipcode, string latitude, string longitude)
    {
        City = city;
        Street = street;
        Number = number;
        Zipcode = zipcode;
        Geolocation = new Geolocation(latitude, longitude);
    }

    /// <summary>
    /// Performs validation of the Address value object using the AddressValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Lat format and length</list>
    /// <list type="bullet">Long format and length</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new AddressValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return  City;
        yield return  Street;
        yield return  Number;
        yield return  Zipcode;
    }
}