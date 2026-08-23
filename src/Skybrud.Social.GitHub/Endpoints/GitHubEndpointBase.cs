namespace Skybrud.Social.GitHub.Endpoints;

/// <summary>
/// Abstract class representing an endpoint of the GitHub API.
/// </summary>
public abstract class GitHubEndpointBase {

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The HTTP service instance.</param>
    protected GitHubEndpointBase(GitHubHttpService service) {
        Service = service;
    }

}