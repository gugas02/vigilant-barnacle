using Ambev.DeveloperEvaluation.Common.Validation;

public class DomainException : Exception
{
    //
    // Summary:
    //     Validation errors
    public IEnumerable<ValidationErrorDetail> Errors { get; private set; } = [];

    public DomainException(string message) : base(message)
    {
    }

    public DomainException(string message, Exception innerException) : base(message, innerException)
    {
    }
    
    public DomainException(string message, ValidationResultDetail validationResult): base(message)
    {
        Errors = validationResult.Errors;
    }
}
