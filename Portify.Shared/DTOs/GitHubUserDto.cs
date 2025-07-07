using System;

namespace Portify.Shared.DTOs
{
    public sealed record GitHubUserDto(
        int Id,
        string Login,
        string Email,
        string AvatarUrl,
        string Bio,
        string Location,
        string Company,
        string Blog
    );
}
