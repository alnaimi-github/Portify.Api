namespace Portify.Domain.Entities;

/// <summary>
/// Domain entity representing an application user, persisted from GitHub.
/// </summary>
public sealed class User
{
    /// <summary>User unique identifier (GUID).</summary>
    public Guid Id { get; private set; }
    /// <summary>GitHub user ID.</summary>
    public required int GitHubId { get; set; }
    /// <summary>Username.</summary>
    public required string UserName { get; set; }
    /// <summary>Email address.</summary>
    public required string Email { get; set; }
    /// <summary>Avatar image URL.</summary>
    public string? AvatarUrl { get; private set; }
    /// <summary>Bio/description.</summary>
    public string? Bio { get; private set; }
    /// <summary>Location.</summary>
    public string? Location { get; private set; }
    /// <summary>Company.</summary>
    public string? Company { get; private set; }
    /// <summary>Blog or website URL.</summary>
    public string? Blog { get; private set; }
    /// <summary>Number of public repositories.</summary>
    public int PublicRepos { get; private set; } = 0;
    /// <summary>Number of followers.</summary>
    public int Followers { get; private set; } = 0;
    /// <summary>Number of following.</summary>
    public int Following { get; private set; } = 0;
    /// <summary>OAuth access token.</summary>
    public string? AccessToken { get; private set; }
    /// <summary>OAuth refresh token.</summary>
    public string? RefreshToken { get; private set; }
    /// <summary>Token expiration date/time.</summary>
    public DateTime? TokenExpiresAt { get; private set; }
    /// <summary>Subscription ID (if any).</summary>
    public Guid? SubscriptionId { get; private set; }
    /// <summary>Whether onboarding is completed.</summary>
    public bool OnboardingCompleted { get; private set; } = false;
    /// <summary>User preferences (JSON).</summary>
    public string Preferences { get; private set; } = "{}";
    /// <summary>Date/time user was created.</summary>
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    /// <summary>Date/time user was last updated.</summary>
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    /// <summary>Date/time of last sync.</summary>
    public DateTime? LastSync { get; private set; }
    /// <summary>Date/time of last login.</summary>
    public DateTime? LastLogin { get; private set; }
    /// <summary>Whether the user is active.</summary>
    public bool IsActive { get; private set; } = true;

    private readonly List<UserLink> _links = new List<UserLink>();
    /// <summary>User's external links (e.g., social, portfolio).</summary>
    public IReadOnlyCollection<UserLink> Links => _links.AsReadOnly();

    /// <summary>
    /// Private constructor for EF Core.
    /// </summary>
    private User() { }

    /// <summary>
    /// Factory method to create a new User entity.
    /// </summary>
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
