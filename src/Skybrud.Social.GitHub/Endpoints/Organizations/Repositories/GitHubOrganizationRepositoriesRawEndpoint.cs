using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Organizations.Repositories;

namespace Skybrud.Social.GitHub.Endpoints.Organizations.Repositories;

/// <summary>
/// Class representing the raw <strong>Organization / Repositories</strong> endpoint.
/// </summary>
public class GitHubOrganizationRepositoriesRawEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent OAuth client.
    /// </summary>
    public GitHubOAuthClient Client { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The OAuth instance.</param>
    public GitHubOrganizationRepositoriesRawEndpoint(GitHubOAuthClient client) {
        Client = client;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a list of repositories of the organization matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetRepositories(GitHubGetRepositoriesOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

}