using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.WebApi.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Command for retrieving a product by their ID
/// </summary>
public class GetProductsCommand : PaginationApiCommand, IRequest<PaginatedList<GetProductsResult>>
{
    
}
