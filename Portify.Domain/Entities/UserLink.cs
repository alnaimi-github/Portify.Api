using Portify.Domain.Enums;

namespace Portify.Domain.Entities;

public sealed class UserLink
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public PlatformType Platform { get; private set; }
    public string Url { get; private set; }

    // Private constructor for EF Core
    private UserLink() { }

    // Factory method to create a UserLink
    public static UserLink Create(Guid userId, PlatformType platform, string url) =>
        new()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Platform = platform,
            Url = url
        };

    public void UpdateUrl(string url) => Url = url;
}
