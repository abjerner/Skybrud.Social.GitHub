using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.User.Organizations;

namespace Skybrud.Social.GitHub.Endpoints.User.Organizations;

/// <summary>
/// Class representing the raw <strong>User / Organizations</strong> endpoint.
/// </summary>
public class GitHubUserOrganizationsRawEndpoint {

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
    public GitHubUserOrganizationsRawEndpoint(GitHubOAuthClient client) {
        Client = client;
    }

    #endregion

    #region GetOrganizations(...)

    /// <summary>
    /// Gets a list of organizations the authenticated user is a member of.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-the-authenticated-user</cref>
    /// </see>
    public async Task<IHttpResponse> GetOrganizations() {
        return await GetOrganizations(new GitHubGetOrganizationsOptions());
    }

    /// <summary>
    /// Returns a list of organizations the authenticated user is a member of.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-the-authenticated-user</cref>
    /// </see>
    public async Task<IHttpResponse> GetOrganizations(GitHubGetOrganizationsOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

}