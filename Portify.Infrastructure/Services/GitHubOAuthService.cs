using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Portify.Shared.DTOs;
using Portify.Infrastructure.Configuration.Settings;

namespace Portify.Infrastructure.Services;

public class GitHubOAuthService
{
    private readonly HttpClient _httpClient;
    private readonly GitHubOAuthConfig _config;

    public GitHubOAuthService(HttpClient httpClient, IOptions<GitHubOAuthConfig> config)
    {
        _httpClient = httpClient;
        _config = config.Value;
    }

    public string GetAuthorizationUrl(string state)
    {
        // Join scopes with space as required by GitHub
        string scopes = string.Join("%20", _config.Scopes);
        string url = $"{_config.AuthorizationEndpoint}?client_id={_config.ClientId}&redirect_uri={_config.RedirectUri}&scope={scopes}&state={state}";
        return url;
    }

    public async Task<string> ExchangeCodeForTokenAsync(string code)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, _config.TokenEndpoint);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("client_id", _config.ClientId),
            new KeyValuePair<string, string>("client_secret", _config.ClientSecret),
            new KeyValuePair<string, string>("code", code),
            new KeyValuePair<string, string>("redirect_uri", _config.RedirectUri)
        });

        HttpResponseMessage response = await _httpClient.SendAsync(request);
        string payload = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"GitHub token endpoint returned an error: {response.StatusCode} - {payload}");
        }

        using var doc = JsonDocument.Parse(payload);
        if (doc.RootElement.TryGetProperty("access_token", out JsonElement tokenElem) && tokenElem.GetString() is { } token)
        {
            return token;
        }

        if (doc.RootElement.TryGetProperty("error", out JsonElement errorElem))
        {
            string error = errorElem.GetString() ?? "Unknown error";
            throw new InvalidOperationException($"GitHub returned an error: {error}");
        }

        throw new InvalidOperationException("GitHub did not return an access_token.");
    }

    public async Task<GitHubUserDto> GetUserAsync(string accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, _config.UserInfoEndpoint);
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Portify", "1.0"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        HttpResponseMessage? response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        string? json = await response.Content.ReadAsStringAsync();
        GitHubUserDto? user = JsonSerializer.Deserialize<GitHubUserDto>(json);
        if (user is null)
        {
            throw new InvalidOperationException("Failed to deserialize GitHub user info.");
        }

        return user;
    }

    public async Task<List<GitHubRepoDto>> GetUserReposAsync(string accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/user/repos");
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Portify", "1.0"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        HttpResponseMessage? response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        string? json = await response.Content.ReadAsStringAsync();
        List<GitHubRepoDto>? repos = JsonSerializer.Deserialize<List<GitHubRepoDto>>(json);
        if (repos is null)
        {
            throw new InvalidOperationException("Failed to deserialize GitHub repositories.");
        }

        return repos;
    }
}
