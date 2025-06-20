using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;

/// <summary>
/// API response model for GetCart operation
/// </summary>
public class DeleteCartResponse : ApiResponse
{
    /// <summary>
    /// Gets or sets the message result of deleted cart.
    /// </summary>
    public string Message { get; set; } = string.Empty;
}
