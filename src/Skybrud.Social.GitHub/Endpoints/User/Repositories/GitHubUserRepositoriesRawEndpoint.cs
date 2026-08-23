using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Repositories;
using Skybrud.Social.GitHub.Options.User.Repositories;

namespace Skybrud.Social.GitHub.Endpoints.User.Repositories;

/// <summary>
/// Class representing the raw <strong>User / Repositories</strong> endpoint.
/// </summary>
public class GitHubUserRepositoriesRawEndpoint {

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
    public GitHubUserRepositoriesRawEndpoint(GitHubOAuthClient client) {
        Client = client;
    }

    #endregion

    #region CreateRepository(...)

    /// <summary>
    /// Creates a new repository for the authenticated user.
    /// </summary>
    /// <param name="name">The name of the repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<IHttpResponse> CreateRepository(string name) {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return await CreateRepository(new GitHubCreateUserRepositoryOptions(name));
    }

    /// <summary>
    /// Creates a new repository for the authenticated user.
    /// </summary>
    /// <param name="name">The name of the repository.</param>
    /// <param name="isPrivate">Whether to create a new private repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<IHttpResponse> CreateRepository(string name, bool isPrivate) {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return await CreateRepository(new GitHubCreateUserRepositoryOptions(name, isPrivate));
    }

    /// <summary>
    /// Creates a new repository for the authenticated user.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<IHttpResponse> CreateRepository(GitHubCreateUserRepositoryOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region GetRepositories(...)

    /// <summary>
    /// Gets a list of repositories of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetRepositories() {
        return await GetRepositories(new GitHubGetRepositoriesOptions());
    }

    /// <summary>
    /// Gets a list of repositories of the authenticated user.
    /// </summary>
    /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetRepositories(int? perPage = null, int? page = null) {
        return await GetRepositories(new GitHubGetRepositoriesOptions(perPage, page));
    }

    /// <summary>
    /// Gets a list of repositories of the authenticated user.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetRepositories(GitHubGetRepositoriesOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

}