using System.Threading.Tasks;
using Skybrud.Social.GitHub.Models.Users;
using Skybrud.Social.GitHub.Options.Users;
using Skybrud.Social.GitHub.Responses.Repositories;

// ReSharper disable MethodOverloadWithOptionalParameter

namespace Skybrud.Social.GitHub.Endpoints.Users;

public partial class GitHubUsersEndpoint {

    /// <summary>
    /// Gets a list of repositories of the user with the specified <paramref name="userId"/>.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
    public async Task<GitHubRepositoryListResponse> GetRepositories(int userId) {
        return new GitHubRepositoryListResponse(await Raw.GetRepositories(userId));
    }

    /// <summary>
    /// Gets a list of repositories of the user with the specified <paramref name="userId"/>.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="perPage">The maximum amount of repositories to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
    public async Task<GitHubRepositoryListResponse> GetRepositories(int userId, int? perPage = null, int? page = null) {
        return new GitHubRepositoryListResponse(await Raw.GetRepositories(userId, perPage, page));
    }

    /// <summary>
    /// Gets a list of repositories of the user with the specified <paramref name="username"/>.
    /// </summary>
    /// <param name="username">The username (login) of the user.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
    public async Task<GitHubRepositoryListResponse> GetRepositories(string username) {
        return new GitHubRepositoryListResponse(await Raw.GetRepositories(username));
    }

    /// <summary>
    /// Gets a list of repositories of the user with the specified <paramref name="username"/>.
    /// </summary>
    /// <param name="username">The username (login) of the user.</param>
    /// <param name="perPage">The maximum amount of repositories to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
    public async Task<GitHubRepositoryListResponse> GetRepositories(string username, int? perPage = null, int? page = null) {
        return new GitHubRepositoryListResponse(await Raw.GetRepositories(username, perPage, page));
    }

    /// <summary>
    /// Gets a list of repositories of the specified <paramref name="user"/>.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
    public async Task<GitHubRepositoryListResponse> GetRepositories(GitHubUserBase user) {
        return new GitHubRepositoryListResponse(await Raw.GetRepositories(user));
    }

    /// <summary>
    /// Gets a list of repositories of the specified <paramref name="user"/>.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <param name="perPage">The maximum amount of repositories to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
    public async Task<GitHubRepositoryListResponse> GetRepositories(GitHubUserBase user, int? perPage = null, int? page = null) {
        return new GitHubRepositoryListResponse(await Raw.GetRepositories(user, perPage, page));
    }

    /// <summary>
    /// Gets a list of repositories of the user matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
    public async Task<GitHubRepositoryListResponse> GetRepositories(GitHubGetRepositoriesOptions options) {
        return new GitHubRepositoryListResponse(await Raw.GetRepositories(options));
    }

}