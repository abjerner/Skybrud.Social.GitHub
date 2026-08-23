using System.Threading.Tasks;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Tags;
using Skybrud.Social.GitHub.Responses.Tags;

namespace Skybrud.Social.GitHub.Endpoints.Repositories.Tags;

/// <summary>
/// Class representing the <strong>Repositories / Tags</strong> endpoint.
/// </summary>
public class GitHubRepositoryTagsEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubRepositoryRawEndpoint Raw => Service.Client.Repositories.Tags;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The HTTP service instance.</param>
    public GitHubRepositoryTagsEndpoint(GitHubHttpService service) {
        Service = service;
    }

    #endregion

    /// <summary>
    /// Returns a list of tags of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="ownerAlias">The username of the parent user or organization.</param>
    /// <param name="repositoryAlias">The alias of the repository.</param>
    /// <returns>An instance of <see cref="GitHubTagListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-tags</cref>
    /// </see>
    public async Task<GitHubTagListResponse> GetTags(string ownerAlias, string repositoryAlias) {
        return new GitHubTagListResponse(await Raw.GetTags(ownerAlias, repositoryAlias));
    }

    /// <summary>
    /// Returns a list of tags of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="ownerAlias">The username of the parent user or organization.</param>
    /// <param name="repositoryAlias">The alias of the repository.</param>
    /// <param name="perPage">The maximum amount of collaborators to returned by each page.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubTagListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-tags</cref>
    /// </see>
    public async Task<GitHubTagListResponse> GetTags(string ownerAlias, string repositoryAlias, int? perPage = null, int? page = null) {
        return new GitHubTagListResponse(await Raw.GetTags(ownerAlias, repositoryAlias, perPage, page));
    }

    /// <summary>
    /// Returns a list of tags of the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <returns>An instance of <see cref="GitHubTagListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-tags</cref>
    /// </see>
    public async Task<GitHubTagListResponse> GetTags(GitHubRepositoryBase repository) {
        return new GitHubTagListResponse(await Raw.GetTags(repository));
    }

    /// <summary>
    /// Returns a list of tags of the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="perPage">The maximum amount of collaborators to returned by each page.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubTagListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-tags</cref>
    /// </see>
    public async Task<GitHubTagListResponse> GetTags(GitHubRepositoryBase repository, int? perPage = null, int? page = null) {
        return new GitHubTagListResponse(await Raw.GetTags(repository, perPage, page));
    }

    /// <summary>
    /// Returns a list of tags of the repository matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubTagListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repository-tags</cref>
    /// </see>
    public async Task<GitHubTagListResponse> GetTags(GitHubGetTagsOptions options) {
        return new GitHubTagListResponse(await Raw.GetTags(options));
    }

}