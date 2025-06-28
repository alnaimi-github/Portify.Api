namespace Portify.Domain.Entities;

public class Repository
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    public string? GitHubUrl { get; set; }

    public string? LiveDemoUrl { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;


}
