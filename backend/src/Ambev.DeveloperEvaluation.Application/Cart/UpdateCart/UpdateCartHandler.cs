using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Handler for processing UpdateCartCommand requests
/// </summary>
public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;


    /// <summary>
    /// Initializes a new instance of UpdateCartHandler
    /// </summary>
    /// <param name="cartRepository">The cart repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateCartCommand</param>
    public UpdateCartHandler(ICartRepository cartRepository, IMapper mapper, IUserRepository userRepository, IProductRepository productRepository)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    /// <summary>
    /// Handles the UpdateCartCommand request
    /// </summary>
    /// <param name="command">The UpdateCart command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated cart details</returns>
    public async Task<UpdateCartResult> Handle(UpdateCartCommand command, CancellationToken cancellationToken)
    {
        var existingCart = await _cartRepository.GetByIdAsync(command.Id, cancellationToken);
        if (existingCart == null)
            throw new ValidationException($"Cart with email {command.Id} not found.");

        var existingUser = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);
        if (existingUser == null)
            throw new ValidationException($"User with id {command.UserId} not found.");

        var allProductsExists = await _productRepository.GetByIdsAsync(command.Products.Select(x => x.ProductId).ToList(), cancellationToken);
        if (allProductsExists is null || !allProductsExists.Any())
            throw new ValidationException($"Some products were not found.");

        var newCart = _mapper.Map<Cart>(command);
        newCart.SetUser(existingUser);
        newCart.SetProducts(allProductsExists);
        var validationErros = newCart.Validate();
        if(!validationErros.IsValid)
            throw new DomainException($"Invalid input data", validationErros);

        existingCart.Update(newCart);

        _cartRepository.Update(existingCart, cancellationToken);
        var result = _mapper.Map<UpdateCartResult>(existingCart);
        return result;
    }
}
