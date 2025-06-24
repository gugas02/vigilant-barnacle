using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItem;
using Ambev.DeveloperEvaluation.Application.CartItems.UpdateCartItem;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCarts;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Application.Users.GetUsers;
using Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

using Ambev.DeveloperEvaluation.Common.Security;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class ApplicationModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
        builder.Services.AddScoped<IValidator<GetUserCommand>, GetUserCommandValidator>();
        builder.Services.AddScoped<IValidator<GetUsersCommand>, GetUsersCommandValidator>();
        builder.Services.AddScoped<IValidator<DeleteUserCommand>, DeleteUserCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();

        builder.Services.AddScoped<IValidator<AuthenticateUserCommand>, AuthenticateUserValidator>();        

        builder.Services.AddScoped<IValidator<CreateProductCommand>, CreateProductCommandValidator>();
        builder.Services.AddScoped<IValidator<GetProductCommand>, GetProductCommandValidator>();
        builder.Services.AddScoped<IValidator<GetProductsCommand>, GetProductsCommandValidator>();
        builder.Services.AddScoped<IValidator<DeleteProductCommand>, DeleteProductCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateProductCommand>, UpdateProductCommandValidator>();

        builder.Services.AddScoped<IValidator<CreateCartCommand>, CreateCartCommandValidator>();
        builder.Services.AddScoped<IValidator<GetCartCommand>, GetCartCommandValidator>();
        builder.Services.AddScoped<IValidator<GetCartsCommand>, GetCartsCommandValidator>();
        builder.Services.AddScoped<IValidator<DeleteCartCommand>, DeleteCartCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateCartCommand>, UpdateCartCommandValidator>();

        builder.Services.AddScoped<IValidator<CreateCartItemCommand>, CreateCartItemCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateCartItemCommand>, UpdateCartItemCommandValidator>();

        builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
    }
}