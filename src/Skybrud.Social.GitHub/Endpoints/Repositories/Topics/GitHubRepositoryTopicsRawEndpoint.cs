using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Repositories.Topics;

namespace Skybrud.Social.GitHub.Endpoints.Repositories.Topics;

/// <summary>
/// Class representing the raw <strong>Repositories / Topics</strong> endpoint.
/// </summary>
public class GitHubRepositoryTopicsRawEndpoint {

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
    public GitHubRepositoryTopicsRawEndpoint(GitHubOAuthClient client) {
        Client = client;
    }

    #endregion

    #region GetTopics(...)

    /// <summary>
    /// Returns a list of topics for the specified <paramref name="owner"/> and <paramref name="repo"/>.
    /// </summary>
    /// <param name="owner">The alias (login) of the owner of the repository.</param>
    /// <param name="repo">The alias (name/slug) of the repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#get-all-repository-topics"/>
    public async Task<IHttpResponse> GetTopics(string owner, string repo) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repo)) throw new ArgumentNullException(nameof(repo));
        return await GetTopics(new GitHubGetTopicsOptions(owner, repo));
    }

    /// <summary>
    /// Returns a list of topics for the specified <paramref name="owner"/> and <paramref name="repo"/>.
    /// </summary>
    /// <param name="owner">The alias (login) of the owner of the repository.</param>
    /// <param name="repo">The alias (name/slug) of the repository.</param>
    /// <param name="perPage">The maximum amount of topics to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#get-all-repository-topics"/>
    public async Task<IHttpResponse> GetTopics(string owner, string repo, int? perPage = null, int? page = null) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repo)) throw new ArgumentNullException(nameof(repo));
        return await GetTopics(new GitHubGetTopicsOptions(owner, repo, perPage, page));
    }

    /// <summary>
    /// Returns a list of topics for the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#get-all-repository-topics"/>
    public async Task<IHttpResponse> GetTopics(GitHubRepositoryBase repository) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        return await GetTopics(new GitHubGetTopicsOptions(repository));
    }

    /// <summary>
    /// Returns a list of topics for the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="perPage">The maximum amount of topics to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#get-all-repository-topics"/>
    public async Task<IHttpResponse> GetTopics(GitHubRepositoryBase repository, int? perPage = null, int? page = null) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        return await GetTopics(new GitHubGetTopicsOptions(repository, perPage, page));
    }

    /// <summary>
    /// Returns a list of topics of the repository matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#get-all-repository-topics"/>
    public async Task<IHttpResponse> GetTopics(GitHubGetTopicsOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region ReplaceTopics(...)

    /// <summary>
    /// Replaces the topics of the repository matching specified <paramref name="owner"/> and <paramref name="repo"/>.
    /// </summary>
    /// <param name="owner">The alias (login) of the owner of the repository.</param>
    /// <param name="repo">The alias (name/slug) of the repository.</param>
    /// <param name="names">The list of topics to set for the repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#replace-all-repository-topics"/>
    public async Task<IHttpResponse> ReplaceTopics(string owner, string repo, IReadOnlyList<string> names) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repo)) throw new ArgumentNullException(nameof(repo));
        return await ReplaceTopics(new GitHubReplaceTopicsOptions(owner, repo, names));
    }

    /// <summary>
    /// Replaces the topics of the repository matching specified <paramref name="owner"/> and <paramref name="repo"/>.
    /// </summary>
    /// <param name="owner">The alias (login) of the owner of the repository.</param>
    /// <param name="repo">The alias (name/slug) of the repository.</param>
    /// <param name="names">The list of topics to set for the repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#replace-all-repository-topics"/>
    public async Task<IHttpResponse> ReplaceTopics(string owner, string repo, IEnumerable<string> names) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repo)) throw new ArgumentNullException(nameof(repo));
        return await ReplaceTopics(new GitHubReplaceTopicsOptions(owner, repo, names));
    }

    /// <summary>
    /// Replaces the topics of the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="names">The list of topics to set for the repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#replace-all-repository-topics"/>
    public async Task<IHttpResponse> ReplaceTopics(GitHubRepositoryBase repository, IReadOnlyList<string> names) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        return await ReplaceTopics(new GitHubReplaceTopicsOptions(repository, names));
    }

    /// <summary>
    /// Replaces the topics of the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="names">The list of topics to set for the repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#replace-all-repository-topics"/>
    public async Task<IHttpResponse> ReplaceTopics(GitHubRepositoryBase repository, IEnumerable<string> names) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        return await ReplaceTopics(new GitHubReplaceTopicsOptions(repository, names));
    }

    /// <summary>
    /// Replaces the topics of the repository matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#replace-all-repository-topics"/>
    public async Task<IHttpResponse> ReplaceTopics(GitHubReplaceTopicsOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

}