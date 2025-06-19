using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

/// <summary>
/// Profile for mapping between Product entity and DeleteProductResponse
/// </summary>
public class DeleteProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteProduct operation
    /// </summary>
    public DeleteProductProfile()
    {
        CreateMap<Product, DeleteProductResult>();
    }
}
