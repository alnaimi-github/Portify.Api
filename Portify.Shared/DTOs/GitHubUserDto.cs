using System;

namespace Portify.Shared.DTOs
{
    public sealed record GitHubRepoDto(
        int Id,
        string Name,
        string Description,
        string Language,
        int Stars,
        int Forks,
        bool Private,
        string HtmlUrl
    );
}
