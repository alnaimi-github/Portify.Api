namespace Portify.Domain.Entities;

public sealed class User
{
    public Guid Id { get; private set; }
    public int GitHubId { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string? AvatarUrl { get; private set; }
    public string? Bio { get; private set; }
    public string? Location { get; private set; }
    public string? Company { get; private set; }
    public string? Blog { get; private set; }
    public int PublicRepos { get; private set; } = 0;
    public int Followers { get; private set; } = 0;
    public int Following { get; private set; } = 0;
    public string? AccessToken { get; private set; }
    public string? RefreshToken { get; private set; }
    public DateTime? TokenExpiresAt { get; private set; }
    public Guid? SubscriptionId { get; private set; }
    public bool OnboardingCompleted { get; private set; } = false;
    public string Preferences { get; private set; } = "{}";
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? LastSync { get; private set; }
    public DateTime? LastLogin { get; private set; }
    public bool IsActive { get; private set; } = true;

    private readonly List<UserLink> _links = [];
    public IReadOnlyCollection<UserLink> Links => _links.AsReadOnly();

    // Private constructor for EF Core
    private User() { }

    // Factory method to create a User
    public static User Create(
        Guid id,
        int gitHubId,
        string userName,
        string email,
        string? avatarUrl = null,
        string? bio = null,
        string? location = null,
        string? company = null,
        string? blog = null) =>
        new()
        {
            Id = id,
            GitHubId = gitHubId,
            UserName = userName,
            Email = email,
            AvatarUrl = avatarUrl,
            Bio = bio,
            Location = location,
            Company = company,
            Blog = blog
        };

    public void UpdateUserName(string userName)
    {
        UserName = userName;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateEmail(string email)
    {
        Email = email;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddLink(UserLink link)
    {
        _links.Add(link);
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdatePreferences(string preferences)
    {
        Preferences = preferences;
        UpdatedAt = DateTime.UtcNow;
    }

    public void MarkAsInactive()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }
}
