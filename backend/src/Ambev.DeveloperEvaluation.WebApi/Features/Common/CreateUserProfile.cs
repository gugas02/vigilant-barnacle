using Ambev.DeveloperEvaluation.Application.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Common;

/// <summary>
/// Profile for mapping between Application and Common Models 
/// </summary>
public class CommonProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for Common feature
    /// </summary>
    public CommonProfile()
    {
        CreateMap<CreateNameRequest, CreateNameCommand>();
        CreateMap<CreateNameCommand, CreateNameRequest>();

        CreateMap<CreateGeolocationRequest, CreateGeolocationCommand>();
        CreateMap<CreateGeolocationCommand, CreateGeolocationRequest>();
        
        CreateMap<CreateAddressRequest, CreateAddressCommand>();
        CreateMap<CreateAddressCommand, CreateAddressRequest>();
    }
}