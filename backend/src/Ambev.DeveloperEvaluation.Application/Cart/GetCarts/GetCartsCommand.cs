using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.WebApi.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCarts;

/// <summary>
/// Command for retrieving a cart by their ID
/// </summary>
public class GetCartsCommand : PaginationApiCommand, IRequest<PaginatedList<GetCartsResult>>
{
    
}
