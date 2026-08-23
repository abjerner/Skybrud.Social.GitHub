using System.Threading.Tasks;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Issues;
using Skybrud.Social.GitHub.Responses.Issues;

namespace Skybrud.Social.GitHub.Endpoints.Repositories.Issues;

/// <summary>
/// Class representing the <strong>Repositories / Issues</strong> endpoint.
/// </summary>
public class GitHubRepositoryIssuesEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubRepositoryIssuesRawEndpoint Raw => Service.Client.Repositories.Issues;

    #endregion

    #region Constructors

    internal GitHubRepositoryIssuesEndpoint(GitHubHttpService service) {
        Service = service;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Gets a list of issues for the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="owner">The alias of the parent user or organization.</param>
    /// <param name="repositoryAlias">The alias of the repository.</param>
    /// <returns>An instance of <see cref="GitHubIssueListResponse"/> representing the response.</returns>
    public async Task<GitHubIssueListResponse> GetIssues(string owner, string repositoryAlias) {
        return new GitHubIssueListResponse(await Raw.GetIssues(owner, repositoryAlias));
    }

    /// <summary>
    /// Gets a list of issues for the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="owner">The alias of the parent user or organization.</param>
    /// <param name="repositoryAlias">The alias of the repository.</param>
    /// <param name="perPage">The maximum amount of issues to be returned by each page.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubIssueListResponse"/> representing the response.</returns>
    public async Task<GitHubIssueListResponse> GetIssues(string owner, string repositoryAlias, int? perPage = null, int? page = null) {
        return new GitHubIssueListResponse(await Raw.GetIssues(owner, repositoryAlias, perPage, page));
    }

    /// <summary>
    /// Gets a list of issues for the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <returns>An instance of <see cref="GitHubIssueListResponse"/> representing the response.</returns>
    public async Task<GitHubIssueListResponse> GetIssues(GitHubRepositoryBase repository) {
        return new GitHubIssueListResponse(await Raw.GetIssues(repository));
    }

    /// <summary>
    /// Gets a list of issues for the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="perPage">The maximum amount of issues to be returned by each page.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubIssueListResponse"/> representing the response.</returns>
    public async Task<GitHubIssueListResponse> GetIssues(GitHubRepositoryBase repository, int? perPage = null, int? page = null) {
        return new GitHubIssueListResponse(await Raw.GetIssues(repository, perPage, page));
    }

    /// <summary>
    /// Gets a list of issues for the repository matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubIssueListResponse"/> representing the response.</returns>
    public async Task<GitHubIssueListResponse> GetIssues(GitHubGetRepositoryIssuesOptions options) {
        return new GitHubIssueListResponse(await Raw.GetIssues(options));
    }

    #endregion

}