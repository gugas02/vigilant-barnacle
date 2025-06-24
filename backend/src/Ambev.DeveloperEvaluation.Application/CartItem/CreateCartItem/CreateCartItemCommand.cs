using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItem;

/// <summary>
/// Command for creating a new cartItem.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a cartItem, 
/// including date, user id and products. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateCartItemResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateCartItemCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateCartItemCommand : IRequest<CreateCartItemResult>
{
    /// <summary>
    /// Gets the cartItem's ProductId.
    /// Must not be null or empty and should contain ProductId.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets the cartItem's Quantity.
    /// Must not be null or empty and should contain Quantity.
    /// </summary>
    public int Quantity { get; set; } 

    public ValidationResultDetail Validate()
    {
        var validator = new CreateCartItemCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}