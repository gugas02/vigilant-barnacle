using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IProductRepository using Entity Framework Core
/// </summary>
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    /// <summary>
    /// Initializes a new instance of ProductRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ProductRepository(DefaultContext context) : base(context)
    {
    }

    /// <summary>
    /// Creates a new product in the database
    /// </summary>
    /// <param name="product">The product to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product</returns>
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await Add(product, cancellationToken);
        return product;
    }

    /// <summary>
    /// Retrieves a list of products
    /// </summary>
    /// <param name="pageNumber">Page number</param>
    /// <param name="pageSize">Page size</param>
    /// <param name="order">Page order</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    public new async Task<PaginatedQueryResult<Product>> ListAsync(int pageNumber, int pageSize, string order, CancellationToken cancellationToken = default)
    {
        return await base.ListAsync(pageNumber, pageSize, order, cancellationToken);
    }

    /// <summary>
    /// Retrieves a product by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Find(id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a product by their unique identifier
    /// </summary>
    /// <param name="ids">The unique identifiers of the products</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The products if found, null otherwise</returns>
    public async Task<List<Product>?> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default)
    {
        return await Find(x => ids.Contains(x.Id)).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves a product by their productname address
    /// </summary>
    /// <param name="productname">The productname address to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    public async Task<Product?> GetByProductByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await FindFirstOrDefaultAsync(u => u.Title == title, cancellationToken);
    }

    /// <summary>
    /// Deletes a product from the database
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    public void Delete(Product product, CancellationToken cancellationToken = default)
    {
        Remove(product);
    }

    /// <summary>
    /// Update a product in the repository
    /// </summary>
    /// <param name="product">The product to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    public void Update(Product product, CancellationToken cancellationToken = default)
    {
        base.Update(product);
    }

    public async Task<bool> IsIdListValid(List<Guid> list, CancellationToken cancellationToken = default)
    {
        var validIds = await Find(x => list.Contains(x.Id))
                .Select(x => x.Id)
                .ToListAsync(cancellationToken); 

        var invalidIdsLst = list.Except(validIds);

        return !invalidIdsLst.Any();
    }
}
