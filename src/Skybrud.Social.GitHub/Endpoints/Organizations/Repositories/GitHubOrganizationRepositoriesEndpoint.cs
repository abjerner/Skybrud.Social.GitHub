using System;
using System.Threading.Tasks;
using Skybrud.Social.GitHub.Options.Organizations.Repositories;
using Skybrud.Social.GitHub.Responses.Repositories;

namespace Skybrud.Social.GitHub.Endpoints.Organizations.Repositories;

/// <summary>
/// Class representing the <strong>Organizations / Repositories</strong> endpoint.
/// </summary>
public class GitHubOrganizationRepositoriesEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubOrganizationRepositoriesRawEndpoint Raw => Service.Client.Organizations.Repositories;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The HTTP service instance.</param>
    public GitHubOrganizationRepositoriesEndpoint(GitHubHttpService service) {
        Service = service;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a list of repositories of the organization matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
    public async Task<GitHubRepositoryListResponse> GetRepositories(GitHubGetRepositoriesOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return new GitHubRepositoryListResponse(await Raw.GetRepositories(options));
    }

    #endregion

}