using System.Diagnostics.CodeAnalysis;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.CreateCartItem;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.UpdateCartItem;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUsers;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Extensions;

[ExcludeFromCodeCoverage]
public static class AddValidatorExtension
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<AuthenticateUserRequest>, AuthenticateUserRequestValidator>();

        services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
        services.AddScoped<IValidator<GetUserRequest>, GetUserRequestValidator>();
        services.AddScoped<IValidator<GetUsersRequest>, GetUsersRequestValidator>();
        services.AddScoped<IValidator<DeleteUserRequest>, DeleteUserRequestValidator>();
        services.AddScoped<IValidator<UpdateUserRequest>, UpdateUserRequestValidator>();
        
        services.AddScoped<IValidator<CreateProductRequest>, CreateProductRequestValidator>();
        services.AddScoped<IValidator<GetProductRequest>, GetProductRequestValidator>();
        services.AddScoped<IValidator<GetProductsRequest>, GetProductsRequestValidator>();
        services.AddScoped<IValidator<DeleteProductRequest>, DeleteProductRequestValidator>();
        services.AddScoped<IValidator<UpdateProductRequest>, UpdateProductRequestValidator>();
        
        services.AddScoped<IValidator<CreateCartRequest>, CreateCartRequestValidator>();
        services.AddScoped<IValidator<GetCartRequest>, GetCartRequestValidator>();
        services.AddScoped<IValidator<GetCartsRequest>, GetCartsRequestValidator>();
        services.AddScoped<IValidator<DeleteCartRequest>, DeleteCartRequestValidator>();
        services.AddScoped<IValidator<UpdateCartRequest>, UpdateCartRequestValidator>();
        
        services.AddScoped<IValidator<CreateCartItemRequest>, CreateCartItemRequestValidator>();
        services.AddScoped<IValidator<UpdateCartItemRequest>, UpdateCartItemRequestValidator>();
    }
}