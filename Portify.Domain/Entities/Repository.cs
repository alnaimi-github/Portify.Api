namespace Portify.Domain.Entities;

/// <summary>
/// Domain entity representing a GitHub repository persisted in the application.
/// </summary>
public sealed class Repository
{
    /// <summary>Repository unique identifier (GUID).</summary>
    public Guid Id { get; private set; }
    /// <summary>Owner user ID.</summary>
    public required Guid UserId { get; set; }
    /// <summary>GitHub repository ID.</summary>
    public required int GitHubId { get; set; }
    /// <summary>Repository name.</summary>
    public required string Name { get; set; }
    /// <summary>Repository description.</summary>
    public required string Description { get; set; }
    /// <summary>Primary language.</summary>
    public string? Language { get; private set; }
    /// <summary>Star count.</summary>
    public int Stars { get; private set; } = 0;
    /// <summary>Fork count.</summary>
    public int Forks { get; private set; } = 0;
    /// <summary>Is repository private.</summary>
    public bool Private { get; private set; } = false;
    /// <summary>Readme content (if any).</summary>
    public string? ReadmeContent { get; private set; }
    /// <summary>Technologies used (comma-separated).</summary>
    public string? Technologies { get; private set; }
    /// <summary>Repository URL.</summary>
    public string? Url { get; private set; }
    /// <summary>Homepage URL.</summary>
    public string? Homepage { get; private set; }
    /// <summary>Date/time repository was created.</summary>
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    /// <summary>Date/time repository was last updated.</summary>
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    /// <summary>Date/time of last sync.</summary>
    public DateTime? LastSync { get; private set; }

    /// <summary>
    /// Private constructor for EF Core.
    /// </summary>
    private Repository() { }

    /// <summary>
    /// Factory method for creating a Repository entity.
    /// </summary>
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
