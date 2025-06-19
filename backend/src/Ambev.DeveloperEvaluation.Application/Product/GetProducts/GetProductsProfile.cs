using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Application.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Profile for mapping between Product entity and GetProductsResponse
/// </summary>
public class GetProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProducts operation
    /// </summary>
    public GetProductsProfile()
    {
        CreateMap<Product, GetProductsResult>();
        // CreateMap<PaginatedQueryResult<Product>, PaginatedList<GetProductsResult>>();
        CreateMap(typeof(PaginatedQueryResult<>), typeof(PaginatedList<>));
    }
}
