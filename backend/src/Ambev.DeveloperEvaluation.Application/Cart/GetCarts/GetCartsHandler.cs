using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Common;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCarts;

/// <summary>
/// Handler for processing GetCartsCommand requests
/// </summary>
public class GetCartsHandler : IRequestHandler<GetCartsCommand, PaginatedList<GetCartsResult>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetCartsHandler
    /// </summary>
    /// <param name="cartRepository">The cart repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetCartsCommand</param>
    public GetCartsHandler(
        ICartRepository cartRepository,
        IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetCartsCommand request
    /// </summary>
    /// <param name="request">The GetCarts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The cart details if found</returns>
    public async Task<PaginatedList<GetCartsResult>> Handle(GetCartsCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.ListAsync(request.Page, request.Size, request.Order, cancellationToken);
        if (cart == null)
            throw new KeyNotFoundException($"There is no cart registered.");

        return _mapper.Map<PaginatedList<GetCartsResult>>(cart);
    }
}
