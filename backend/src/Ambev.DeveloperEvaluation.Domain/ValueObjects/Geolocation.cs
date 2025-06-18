using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public class Geolocation: BaseValueObject
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

    public Geolocation()
    {
    }
    
    /// <summary>
    /// Initializes a new instance of the Geolocation class.
    /// </summary>
    public Geolocation(string latitude, string longitude)
    {
        Lat = latitude;
        Long = longitude;
    }

    /// <summary>
    /// Performs validation of the Geolocation value object using the GeolocationValidator rules.
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
        var validator = new GeolocationValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Lat;
        yield return Long;
    }
}