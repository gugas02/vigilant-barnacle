using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Represents a request to create a new product in the system.
/// </summary>
public class CreateProductRequest : ApiRequest
{
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
    public CreateRatingRequest Rating { get; set; }
}