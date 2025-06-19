using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Common;

/// <summary>
/// Profile for mapping between value objects and commands
/// </summary>
public class CommonProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for Common operations
    /// </summary>
    public CommonProfile()
    {
        CreateMap<CreateNameCommand, Name>();
        CreateMap<Name, CreateNameCommand>();

        CreateMap<CreateGeolocationCommand, Geolocation>();
        CreateMap<Geolocation, CreateGeolocationCommand>();

        CreateMap<CreateAddressCommand, Address>();
        CreateMap<Address, CreateAddressCommand>();
        
        CreateMap<CreateRatingCommand, Rating>();
        CreateMap<Rating, CreateRatingCommand>();
    }
}
