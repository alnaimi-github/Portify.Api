using Portify.Domain.Enums;

namespace Portify.Domain.Entities;

/// <summary>
/// Domain entity representing a user's external link (e.g., social, portfolio).
/// </summary>
public sealed class UserLink
{
    /// <summary>Link unique identifier (GUID).</summary>
    public Guid Id { get; private set; }
    /// <summary>Owner user ID.</summary>
    public Guid UserId { get; private set; }
    /// <summary>Platform type (e.g., GitHub, Twitter).</summary>
    public PlatformType Platform { get; private set; }
    /// <summary>Link URL.</summary>
    public required string Url { get; set; }

    /// <summary>
    /// Private constructor for EF Core.
    /// </summary>
    private UserLink() { }

    /// <summary>
    /// Factory method to create a UserLink entity.
    /// </summary>
    public static UserLink Create(Guid userId, PlatformType platform, string url) =>
        new()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Platform = platform,
            Url = url
        };

    /// <summary>
    /// Update the link URL.
    /// </summary>
    public void UpdateUrl(string url) => Url = url;
}
