using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public class Name: BaseValueObject
{
    /// <summary>
    /// Gets the user's first name.
    /// Must not be null or empty and should contain first name only.
    /// </summary>
    public string Firstname { get; set; } = string.Empty;

    /// <summary>
    /// Gets the user's Last name.
    /// Must not be null or empty and should contain last name only.
    /// </summary>
    public string Lastname { get; set; } = string.Empty;

    public Name()
    {
    }
    
    /// <summary>
    /// Initializes a new instance of the Name class.
    /// </summary>
    public Name(string firstname, string lastname)
    {
        Firstname = firstname;
        Lastname = lastname;
    }

    /// <summary>
    /// Performs validation of the Name value object using the NameValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Firstname format and length</list>
    /// <list type="bullet">Lastname format and length</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new NameValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Firstname;
        yield return Lastname;
    }
}