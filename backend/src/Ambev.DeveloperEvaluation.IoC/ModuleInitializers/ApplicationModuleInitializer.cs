using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
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
        builder.Services.AddScoped<IValidator<DeleteUserCommand>, DeleteUserCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();

        builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
    }
}