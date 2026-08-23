using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Organizations.Repositories;
using Skybrud.Social.GitHub.Options.Repositories;

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

    #region GetRepositories(...)

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

    #region CreateOrganisationRepository(...)

    /// <summary>
    /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
    /// </summary>
    /// <param name="organisation">The organization who will own the new repository.</param>
    /// <param name="name">The name of the repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<IHttpResponse> CreateRepository(string organisation, string name) {
        if (string.IsNullOrWhiteSpace(organisation)) throw new ArgumentNullException(nameof(organisation));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return await CreateRepository(new GitHubCreateOrganisationRepositoryOptions(organisation, name));
    }

    /// <summary>
    /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
    /// </summary>
    /// <param name="organisation">The organization who will own the new repository.</param>
    /// <param name="name">The name of the repository.</param>
    /// <param name="isPrivate">Whether to create a new private repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<IHttpResponse> CreateRepository(string organisation, string name, bool isPrivate) {
        if (string.IsNullOrWhiteSpace(organisation)) throw new ArgumentNullException(nameof(organisation));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return await CreateRepository(new GitHubCreateOrganisationRepositoryOptions(organisation, name, isPrivate));
    }

    /// <summary>
    /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<IHttpResponse> CreateRepository(GitHubCreateOrganisationRepositoryOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

}