namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

/// <summary>
/// Response model for DeleteCart operation
/// </summary>
public class DeleteCartResult
{
    /// <summary>
    /// Gets or sets the message result of deleted cart.
    /// </summary>
    public string Message { get; set; } = string.Empty;
    public DeleteCartResult(string message)
    {
        Message = message;
    }
}
