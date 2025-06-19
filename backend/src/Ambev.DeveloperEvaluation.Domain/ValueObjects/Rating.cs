using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public class Rating: BaseValueObject
{
    /// <summary>
    /// Gets the user's rata.
    /// Must not be null or empty and between 0 and 5.
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// Gets the user's count.
    /// Must not be null and greater or equal to 0.
    /// </summary>
    public int Count { get; set; }

    public Rating()
    {
    }
    
    /// <summary>
    /// Initializes a new instance of the Rating class.
    /// </summary>
    public Rating(decimal rate, int count)
    {
        Rate = rate;
        Count = count;
    }

    /// <summary>
    /// Performs validation of the Rating value object using the RatingValidator rules.
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
        var validator = new RatingValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Rate;
        yield return Count;
    }
}