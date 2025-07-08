namespace Portify.Shared.DTOs;

/// <summary>
/// Data Transfer Object representing a GitHub repository.
/// </summary>
public sealed record GitHubRepoDto(
    /// <summary>Repository ID.</summary>
    int Id,
    /// <summary>Repository name.</summary>
    string Name,
    /// <summary>Repository description.</summary>
    string Description,
    /// <summary>Primary language.</summary>
    string Language,
    /// <summary>Star count.</summary>
    int Stars,
    /// <summary>Fork count.</summary>
    int Forks,
    /// <summary>Is repository private.</summary>
    bool Private,
    /// <summary>Repository HTML URL.</summary>
    string HtmlUrl
);
