using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Users.UpdateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

/// <summary>
/// Profile for mapping between Application and API UpdateUser responses
/// </summary>
public class UpdateUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateUser feature
    /// </summary>
    public UpdateUserProfile()
    {
        CreateMap<UpdateUserRequest, UpdateUserCommand>()
            .ForMember(x => x.Status, opt => opt.MapFrom(src => Enum.Parse<EUserStatus>(src.Status)))
            .ForMember(x => x.Role, opt => opt.MapFrom(src => Enum.Parse<EUserRole>(src.Role)));
            
        CreateMap<UpdateUserResult, UpdateUserResponse>()
            .ForMember(dest => dest.Status, opt =>  opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
    }
}
