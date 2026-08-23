using Skybrud.Social.GitHub.OAuth;

namespace Skybrud.Social.GitHub.Endpoints;

/// <summary>
/// Abstract class representing a raw endpoint of the GitHub API.
/// </summary>
public abstract class GitHubRawEndpointBase {

    /// <summary>
    /// Gets a reference to the parent OAuth client.
    /// </summary>
    public GitHubOAuthClient Client { get; }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The OAuth instance.</param>
    protected GitHubRawEndpointBase(GitHubOAuthClient client) {
        Client = client;
    }

}