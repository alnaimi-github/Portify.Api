namespace Portify.Infrastructure.Configuration.Settings;

public class GitHubOAuthConfig
{
    required public string ClientId { get; set; }
    required public string ClientSecret { get; set; }
    required public string RedirectUri { get; set; }
    required public string AuthorizationEndpoint { get; set; }
    required public string TokenEndpoint { get; set; }
    required public string UserInfoEndpoint { get; set; }
    required public string[] Scopes { get; set; }
} 
