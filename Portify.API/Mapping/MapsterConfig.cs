using Mapster;
using Portify.Domain.Entities;
using Portify.Shared.DTOs;

namespace Portify.API.Mapping;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        // ReSharper disable once ArrangeMethodOrOperatorBody
        TypeAdapterConfig<GitHubUserDto, User>.NewConfig()
            .Map(dest => dest.GitHubId, src => src.Id)
            .Map(dest => dest.UserName, src => src.Login)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.AvatarUrl, src => src.AvatarUrl)
            .Map(dest => dest.Bio, src => src.Bio)
            .Map(dest => dest.Location, src => src.Location)
            .Map(dest => dest.Company, src => src.Company)
            .Map(dest => dest.Blog, src => src.Blog);
    }
}
