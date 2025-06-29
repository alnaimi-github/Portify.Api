namespace Portify.Domain.Entities;

public sealed class Repository
{
    public Guid Id { get; private set; }
    public required Guid UserId { get; set; }
    public required int GitHubId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? Language { get; private set; }
    public int Stars { get; private set; } = 0;
    public int Forks { get; private set; } = 0;
    public bool Private { get; private set; } = false;
    public string? ReadmeContent { get; private set; }
    public string? Technologies { get; private set; }
    public string? Url { get; private set; }
    public string? Homepage { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? LastSync { get; private set; }

    // Private constructor for EF Core
    private Repository() { }

    // Factory method for creating a Repository
    public static Repository Create(
        Guid id,
        Guid userId,
        int gitHubId,
        string name,
        string description,
        string? language = null,
        int stars = 0,
        int forks = 0,
        bool isPrivate = false,
        string? readmeContent = null,
        string? technologies = null,
        string? url = null,
        string? homepage = null) =>
        new()
        {
            Id = id,
            UserId = userId,
            GitHubId = gitHubId,
            Name = name,
            Description = description,
            Language = language,
            Stars = stars,
            Forks = forks,
            Private = isPrivate,
            ReadmeContent = readmeContent,
            Technologies = technologies,
            Url = url,
            Homepage = homepage
        };

    // Method to update repository details
    public void UpdateDetails(
        string name,
        string description,
        string? language = null,
        int stars = 0,
        int forks = 0,
        bool isPrivate = false,
        string? readmeContent = null,
        string? technologies = null,
        string? url = null,
        string? homepage = null)
    {
        Name = name;
        Description = description;
        Language = language;
        Stars = stars;
        Forks = forks;
        Private = isPrivate;
        ReadmeContent = readmeContent;
        Technologies = technologies;
        Url = url;
        Homepage = homepage;
        UpdatedAt = DateTime.UtcNow;
    }
}
