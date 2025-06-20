using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Common.Transaction;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Handler for processing CreateCartCommand requests
/// </summary>
public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Initializes a new instance of CreateCartHandler
    /// </summary>
    /// <param name="cartRepository">The cart repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateCartCommand</param>
    public CreateCartHandler(ICartRepository cartRepository, IMapper mapper, IUserRepository userRepository, IProductRepository productRepository)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    /// <summary>
    /// Handles the CreateCartCommand request
    /// </summary>
    /// <param name="command">The CreateCart command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created cart details</returns>
    public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);
        if (existingUser == null)
            throw new ValidationException($"User with id {command.UserId} not found.");

        var allProductsExists = await _productRepository.GetByIdsAsync(command.Products.Select(x => x.ProductId).ToList(), cancellationToken);
        if (allProductsExists is null || !allProductsExists.Any())
            throw new ValidationException($"None of the products were found.");

        var cart = _mapper.Map<Cart>(command);
        cart.SetUser(existingUser);
        cart.SetProducts(allProductsExists);
        
        var validationErros = cart.Validate();
        if(!validationErros.IsValid)
            throw new DomainException($"Invalid input data", validationErros);

        var createdCart = await _cartRepository.CreateAsync(cart, cancellationToken);
        return _mapper.Map<CreateCartResult>(createdCart);
    }
}
