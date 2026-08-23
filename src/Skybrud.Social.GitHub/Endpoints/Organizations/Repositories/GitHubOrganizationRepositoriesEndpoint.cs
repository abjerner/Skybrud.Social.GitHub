using System;
using System.Threading.Tasks;
using Skybrud.Social.GitHub.Options.Organizations.Repositories;
using Skybrud.Social.GitHub.Options.Repositories;
using Skybrud.Social.GitHub.Responses.Repositories;

namespace Skybrud.Social.GitHub.Endpoints.Organizations.Repositories;

/// <summary>
/// Class representing the <strong>Organizations / Repositories</strong> endpoint.
/// </summary>
public class GitHubOrganizationRepositoriesEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubOrganizationRepositoriesRawEndpoint Raw => Service.Client.Organizations.Repositories;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The HTTP service instance.</param>
    public GitHubOrganizationRepositoriesEndpoint(GitHubHttpService service) {
        Service = service;
    }

    #endregion

    #region GetRepositories(...)

    /// <summary>
    /// Returns a list of repositories of the organization matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
    public async Task<GitHubRepositoryListResponse> GetRepositories(GitHubGetRepositoriesOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return new GitHubRepositoryListResponse(await Raw.GetRepositories(options));
    }

    #endregion

    #region CreateRepository(...)

    /// <summary>
    /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
    /// </summary>
    /// <param name="organisation">The organization who will own the new repository.</param>
    /// <param name="name">The name of the repository.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateRepository(string organisation, string name) {
        return new GitHubRepositoryResponse(await Raw.CreateRepository(organisation, name));
    }

    /// <summary>
    /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
    /// </summary>
    /// <param name="organisation">The organization who will own the new repository.</param>
    /// <param name="name">The name of the repository.</param>
    /// <param name="isPrivate">Whether to create a new private repository.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateRepository(string organisation, string name, bool isPrivate) {
        return new GitHubRepositoryResponse(await Raw.CreateRepository(organisation, name, isPrivate));
    }

    /// <summary>
    /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateRepository(GitHubCreateOrganisationRepositoryOptions options) {
        return new GitHubRepositoryResponse(await Raw.CreateRepository(options));
    }

    #endregion

}