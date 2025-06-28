namespace Portify.Domain.Entities;

public sealed class User
{
    public Guid Id { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }

    private readonly List<UserLink> _links = [];
    public IReadOnlyCollection<UserLink> Links => _links.AsReadOnly();

    // Private constructor for EF Core
    private User() { }

    // Factory method to create a User
    public static User Create(Guid id, string userName, string email) =>
        new()
        {
            Id = id,
            UserName = userName,
            Email = email
        };
    public void UpdateUserName(string userName) => UserName = userName;
    public void UpdateEmail(string email) => Email = email;

    public void AddLink(UserLink link) => _links.Add(link);
}
