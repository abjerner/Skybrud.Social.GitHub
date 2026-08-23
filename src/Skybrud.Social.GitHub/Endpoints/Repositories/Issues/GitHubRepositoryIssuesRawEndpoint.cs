using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Issues;

namespace Skybrud.Social.GitHub.Endpoints.Repositories.Issues;

/// <summary>
/// Class representing the raw <strong>Repositories / Issues</strong> endpoint.
/// </summary>
public class GitHubRepositoryIssuesRawEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent OAuth client.
    /// </summary>
    public GitHubOAuthClient Client { get; }

    #endregion

    #region Constructors

    internal GitHubRepositoryIssuesRawEndpoint(GitHubOAuthClient client) {
        Client = client;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a list of issues for the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="owner">The alias of the parent user or organization.</param>
    /// <param name="repositoryAlias">The alias of the repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetIssues(string owner, string repositoryAlias) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
        return await GetIssues(new GitHubGetRepositoryIssuesOptions(owner, repositoryAlias));
    }

    /// <summary>
    /// Returns a list of issues for the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="owner">The alias of the parent user or organization.</param>
    /// <param name="repositoryAlias">The alias of the repository.</param>
    /// <param name="perPage">The maximum amount of issues to be returned by each page.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetIssues(string owner, string repositoryAlias, int? perPage = null, int? page = null) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
        return await GetIssues(new GitHubGetRepositoryIssuesOptions(owner, repositoryAlias, perPage, page));
    }

    /// <summary>
    /// Returns a list of issues for the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetIssues(GitHubRepositoryBase repository) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        return await GetIssues(new GitHubGetRepositoryIssuesOptions(repository));
    }

    /// <summary>
    /// Returns a list of issues for the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="perPage">The maximum amount of issues to be returned by each page.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetIssues(GitHubRepositoryBase repository, int? perPage = null, int? page = null) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        return await GetIssues(new GitHubGetRepositoryIssuesOptions(repository, perPage, page));
    }

    /// <summary>
    /// Returns a list of issues for the repository matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetIssues(GitHubGetRepositoryIssuesOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

}