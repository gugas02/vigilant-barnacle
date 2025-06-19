using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Response model for GetProducts operation
/// </summary>
public class GetProductsResult
{
    /// <summary>
    /// The unique identifier of the product
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Gets the product's title.
    /// Must not be null or empty and should contain title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's price.
    /// Must not be null or empty and should contain price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets the product's description.
    /// Must not be null or empty and should contain description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's category.
    /// Must not be null or empty and should contain category.
    /// </summary>    
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's image.
    /// Must not be null or empty and should contain image.
    /// </summary>    
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's rating.
    /// Must not be null or empty and should contain rating.
    /// </summary>
    public CreateRatingCommand Rating { get; set; }
}
