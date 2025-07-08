using Mapster;
using Portify.Domain.Entities;
using Portify.Application.Users.DTOs;

namespace Portify.API.Mapping;

public static class MapsterUserMappings
{
    public static void RegisterUserMappings()
        // ReSharper disable once ArrangeMethodOrOperatorBody
    {
        TypeAdapterConfig<User, AppUserDto>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.AvatarUrl, src => src.AvatarUrl)
            .Map(dest => dest.Name, src => src.UserName) // Adjust as needed
            .Map(dest => dest.Bio, src => src.Bio)
            .Map(dest => dest.Location, src => src.Location)
            .Map(dest => dest.Company, src => src.Company)
            .Map(dest => dest.Blog, src => src.Blog);
    }
}
