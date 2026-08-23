using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Endpoints.User.Repositories;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.User.Organizations;

namespace Skybrud.Social.GitHub.Endpoints.User;

/// <summary>
/// Class representing the raw <strong>User</strong> endpoint.
/// </summary>
public class GitHubUserRawEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent OAuth client.
    /// </summary>
    public GitHubOAuthClient Client { get; }

    /// <summary>
    /// Gets a reference to the <strong>Repositories</strong> endpoint.
    /// </summary>
    public GitHubUserRepositoriesRawEndpoint Repositories { get; }

    #endregion

    #region Constructors

    internal GitHubUserRawEndpoint(GitHubOAuthClient client) {
        Client = client;
        Repositories = new GitHubUserRepositoriesRawEndpoint(client);
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Gets information about the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetUser() {
        return await Client.GetAsync("/user");
    }

    /// <summary>
    /// Gets a list of email addresses of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetEmails() {
        return await Client.GetAsync("/user/emails");
    }

    /// <summary>
    /// Gets a list of users following the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetFollowers() {
        return await Client.GetAsync("/user/followers");
    }

    /// <summary>
    /// Gets a list of users the authenticated user is following.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetFollowing() {
        return await Client.GetAsync("/user/following");
    }

    /// <summary>
    /// Gets whether the authenticated user is following the user with the specified <paramref name="username"/>.
    /// </summary>
    /// <param name="username">The username (login) of the user.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> IsFollowing(string username) {
        if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
        return await Client.GetAsync("/user/following/" + username);
    }

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