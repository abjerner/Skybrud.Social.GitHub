using System.Collections.Generic;
using System.Threading.Tasks;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Topics;
using Skybrud.Social.GitHub.Responses.Topics;

namespace Skybrud.Social.GitHub.Endpoints.Repositories.Topics;

/// <summary>
/// Class representing the <strong>Repositories / Topics</strong> endpoint.
/// </summary>
public class GitHubRepositoryTopicsEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubRepositoryTopicsRawEndpoint Raw => Service.Client.Repositories.Topics;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The HTTP service instance.</param>
    public GitHubRepositoryTopicsEndpoint(GitHubHttpService service) {
        Service = service;
    }

    #endregion

    #region GetTopics(...)

    /// <summary>
    /// Returns a list of topics for the specified <paramref name="owner"/> and <paramref name="repo"/>.
    /// </summary>
    /// <param name="owner">The alias (login) of the owner of the repository.</param>
    /// <param name="repo">The alias (name/slug) of the repository.</param>
    /// <returns>An instance of <see cref="GitHubTopicListResponse"/> representing the response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#get-all-repository-topics"/>
    public async Task<GitHubTopicListResponse> GetTopics(string owner, string repo) {
        return new GitHubTopicListResponse(await Raw.GetTopics(owner, repo));
    }

    /// <summary>
    /// Returns a list of topics for the specified <paramref name="owner"/> and <paramref name="repo"/>.
    /// </summary>
    /// <param name="owner">The alias (login) of the owner of the repository.</param>
    /// <param name="repo">The alias (name/slug) of the repository.</param>
    /// <param name="perPage">The maximum amount of topics to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubTopicListResponse"/> representing the response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#get-all-repository-topics"/>
    public async Task<GitHubTopicListResponse> GetTopics(string owner, string repo, int? perPage = null, int? page = null) {
        return new GitHubTopicListResponse(await Raw.GetTopics(owner, repo, perPage, page));
    }

    /// <summary>
    /// Returns a list of topics for the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <returns>An instance of <see cref="GitHubTopicListResponse"/> representing the response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#get-all-repository-topics"/>
    public async Task<GitHubTopicListResponse> GetTopics(GitHubRepositoryBase repository) {
        return new GitHubTopicListResponse(await Raw.GetTopics(repository));
    }

    /// <summary>
    /// Returns a list of topics for the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="perPage">The maximum amount of topics to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubTopicListResponse"/> representing the response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#get-all-repository-topics"/>
    public async Task<GitHubTopicListResponse> GetTopics(GitHubRepositoryBase repository, int? perPage = null, int? page = null) {
        return new GitHubTopicListResponse(await Raw.GetTopics(repository, perPage, page));
    }

    /// <summary>
    /// Returns a list of topics of the repository matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubTopicListResponse"/> representing the response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#get-all-repository-topics"/>
    public async Task<GitHubTopicListResponse> GetTopics(GitHubGetTopicsOptions options) {
        return new GitHubTopicListResponse(await Raw.GetTopics(options));
    }

    #endregion

    #region ReplaceTopics(...)

    /// <summary>
    /// Replaces the topics of the repository matching specified <paramref name="owner"/> and <paramref name="repo"/>.
    /// </summary>
    /// <param name="owner">The alias (login) of the owner of the repository.</param>
    /// <param name="repo">The alias (name/slug) of the repository.</param>
    /// <param name="names">The list of topics to set for the repository.</param>
    /// <returns>An instance of <see cref="GitHubTopicListResponse"/> representing the response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#replace-all-repository-topics"/>
    public async Task<GitHubTopicListResponse> ReplaceTopics(string owner, string repo, IReadOnlyList<string> names) {
        return new GitHubTopicListResponse(await Raw.ReplaceTopics(owner, repo, names));
    }

    /// <summary>
    /// Replaces the topics of the repository matching specified <paramref name="owner"/> and <paramref name="repo"/>.
    /// </summary>
    /// <param name="owner">The alias (login) of the owner of the repository.</param>
    /// <param name="repo">The alias (name/slug) of the repository.</param>
    /// <param name="names">The list of topics to set for the repository.</param>
    /// <returns>An instance of <see cref="GitHubTopicListResponse"/> representing the response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#replace-all-repository-topics"/>
    public async Task<GitHubTopicListResponse> ReplaceTopics(string owner, string repo, IEnumerable<string> names) {
        return new GitHubTopicListResponse(await Raw.ReplaceTopics(owner, repo, names));
    }

    /// <summary>
    /// Replaces the topics of the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="names">The list of topics to set for the repository.</param>
    /// <returns>An instance of <see cref="GitHubTopicListResponse"/> representing the response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#replace-all-repository-topics"/>
    public async Task<GitHubTopicListResponse> ReplaceTopics(GitHubRepositoryBase repository, IReadOnlyList<string> names) {
        return new GitHubTopicListResponse(await Raw.ReplaceTopics(repository, names));
    }

    /// <summary>
    /// Replaces the topics of the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="names">The list of topics to set for the repository.</param>
    /// <returns>An instance of <see cref="GitHubTopicListResponse"/> representing the response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#replace-all-repository-topics"/>
    public async Task<GitHubTopicListResponse> ReplaceTopics(GitHubRepositoryBase repository, IEnumerable<string> names) {
        return new GitHubTopicListResponse(await Raw.ReplaceTopics(repository, names));
    }

    /// <summary>
    /// Replaces the topics of the repository matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubTopicListResponse"/> representing the response.</returns>
    /// <see href="https://docs.github.com/en/rest/repos/repos?apiVersion=2026-03-10#replace-all-repository-topics"/>
    public async Task<GitHubTopicListResponse> ReplaceTopics(GitHubReplaceTopicsOptions options) {
        return new GitHubTopicListResponse(await Raw.ReplaceTopics(options));
    }

    #endregion

}