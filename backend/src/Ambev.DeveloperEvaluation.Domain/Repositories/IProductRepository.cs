using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Product entity operations
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Creates a new product in the repository
    /// </summary>
    /// <param name="product">The product to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product</returns>
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of products
    /// </summary>
    /// <param name="pageNumber">Page number</param>
    /// <param name="pageSize">Page size</param>
    /// <param name="order">Page order</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    Task<PaginatedQueryResult<Product>> ListAsync(int pageNumber, int pageSize, string order, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a product by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifiers of the products</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The products if found, null otherwise</returns>
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a product by their unique identifiers
    /// </summary>
    /// <param name="ids">The unique identifier of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    Task<List<Product>?> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a product by their name
    /// </summary>
    /// <param name="title">The title to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    Task<Product?> GetByProductByTitleAsync(string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a product from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    void Delete(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a product in the repository
    /// </summary>
    /// <param name="product">The product to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    void Update(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Check if a list of product id exists.
    /// </summary>
    /// <param name="list">The list of product ids</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if entire list found, false otherwise</returns>
    Task<bool> IsIdListValid(List<Guid> list, CancellationToken cancellationToken = default);
}
