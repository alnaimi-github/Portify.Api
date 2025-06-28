namespace Portify.Domain.Entities;

public sealed class Repository
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public string? ImageUrl { get; private set; }
    public string? GitHubUrl { get; private set; }
    public string? LiveDemoUrl { get; private set; }

    public Guid UserId { get; private set; }

    // Private constructor for EF Core
    private Repository() { }

    // Factory method for creating a Repository
    public static Repository Create(
        Guid id,
        string name,
        string description,
        Guid userId,
        string? imageUrl = null,
        string? gitHubUrl = null,
        string? liveDemoUrl = null) =>
        new()
        {
            Id = id,
            Name = name,
            Description = description,
            UserId = userId,
            ImageUrl = imageUrl,
            GitHubUrl = gitHubUrl,
            LiveDemoUrl = liveDemoUrl
        };

    // Method to update the repository details
    public void UpdateDetails(
        string name,
        string description,
        string? imageUrl = null,
        string? gitHubUrl = null,
        string? liveDemoUrl = null)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        GitHubUrl = gitHubUrl;
        LiveDemoUrl = liveDemoUrl;
    }
}
