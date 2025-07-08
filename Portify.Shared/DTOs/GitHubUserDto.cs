using System.Text.Json.Serialization;


namespace Portify.Shared.DTOs;

/// <summary>
/// Data Transfer Object representing a GitHub user profile.
/// </summary>
public sealed record GitHubUserDto(
    /// <summary>GitHub user ID.</summary>
    [property: JsonPropertyName("id")] int Id,
    /// <summary>GitHub username (login).</summary>
    [property: JsonPropertyName("login")] string Login,
    /// <summary>Email address.</summary>
    [property: JsonPropertyName("email")] string? Email,
    /// <summary>Avatar image URL.</summary>
    [property: JsonPropertyName("avatar_url")] string AvatarUrl,
    /// <summary>Full name.</summary>
    [property: JsonPropertyName("name")] string? Name,
    /// <summary>Bio/description.</summary>
    [property: JsonPropertyName("bio")] string? Bio,
    /// <summary>Location.</summary>
    [property: JsonPropertyName("location")] string? Location,
    /// <summary>Company.</summary>
    [property: JsonPropertyName("company")] string? Company,
    /// <summary>Blog or website URL.</summary>
    [property: JsonPropertyName("blog")] string? Blog
);
