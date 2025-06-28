namespace Portify.Infrastructure.Configuration.Settings;

public class GitHubOAuthConfig
{
    public const string SectionName = "GitHubOAuth";
    
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string RedirectUri { get; set; } = string.Empty;
    public string AuthorizationEndpoint { get; set; } = "https://github.com/login/oauth/authorize";
    public string TokenEndpoint { get; set; } = "https://github.com/login/oauth/access_token";
    public string UserInfoEndpoint { get; set; } = "https://api.github.com/user";
    public string[] Scopes { get; set; } = ["read:user", "user:email"];
} 
