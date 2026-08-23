using System.Threading.Tasks;
using Skybrud.Social.GitHub.Options.Repositories;
using Skybrud.Social.GitHub.Options.User.Repositories;
using Skybrud.Social.GitHub.Responses.Repositories;

namespace Skybrud.Social.GitHub.Endpoints.User.Repositories;

/// <summary>
/// Class representing the <strong>User / Repositories</strong> endpoint.
/// </summary>
public class GitHubUserRepositoriesEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubUserRepositoriesRawEndpoint Raw => Service.Client.User.Repositories;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The HTTP service instance.</param>
    public GitHubUserRepositoriesEndpoint(GitHubHttpService service) {
        Service = service;
    }

    #endregion
    #region CreateRepository(...)

    /// <summary>
    /// Creates a new repository for the authenticated user.
    /// </summary>
    /// <param name="name">The name of the repository.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateRepository(string name) {
        return new GitHubRepositoryResponse(await Raw.CreateRepository(name));
    }

    /// <summary>
    /// Creates a new repository for the authenticated user.
    /// </summary>
    /// <param name="name">The name of the repository.</param>
    /// <param name="isPrivate">Whether to create a new private repository.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateRepository(string name, bool isPrivate) {
        return new GitHubRepositoryResponse(await Raw.CreateRepository(name, isPrivate));
    }

    /// <summary>
    /// Creates a new repository for the authenticated user.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateRepository(GitHubCreateUserRepositoryOptions options) {
        return new GitHubRepositoryResponse(await Raw.CreateRepository(options));
    }

    #endregion

    #region GetRepositories(...)

    /// <summary>
    /// Gets a list of repositories of the authenticated user.
    /// </summary>
    /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
    public async Task<GitHubRepositoryListResponse> GetRepositories(int? perPage = null, int? page = null) {
        return new GitHubRepositoryListResponse(await Raw.GetRepositories(perPage, page));
    }

    /// <summary>
    /// Gets a list of repositories of the authenticated user.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
    public async Task<GitHubRepositoryListResponse> GetRepositories(GitHubGetRepositoriesOptions options) {
        return new GitHubRepositoryListResponse(await Raw.GetRepositories(options));
    }

    #endregion

}