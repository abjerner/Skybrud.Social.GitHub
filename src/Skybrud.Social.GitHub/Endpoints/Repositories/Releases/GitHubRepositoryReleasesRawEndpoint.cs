using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Repositories.Releases;

namespace Skybrud.Social.GitHub.Endpoints.Repositories.Releases;

/// <summary>
/// Class representing the raw <strong>Repositories / Releases</strong> endpoint.
/// </summary>
public class GitHubRepositoryReleasesRawEndpoint {

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
    public GitHubRepositoryReleasesRawEndpoint(GitHubOAuthClient client) {
        Client = client;
    }

    #endregion

    #region GetReleases(...)

    /// <summary>
    /// Returns a list of releases of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="ownerAlias">The username of the parent user or organization.</param>
    /// <param name="repositoryAlias">The alias of the repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#list-releases</cref>
    /// </see>
    public async Task<IHttpResponse> GetReleases(string ownerAlias, string repositoryAlias) {
        if (string.IsNullOrWhiteSpace(ownerAlias)) throw new ArgumentNullException(nameof(ownerAlias));
        if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
        return await GetReleases(new GitHubGetReleasesOptions(ownerAlias, repositoryAlias));
    }

    /// <summary>
    /// Returns a list of releases of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="ownerAlias">The username of the parent user or organization.</param>
    /// <param name="repositoryAlias">The alias of the repository.</param>
    /// <param name="perPage">The maximum amount of collaborators to returned by each page. Default is <c>30</c>. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#list-releases</cref>
    /// </see>
    public async Task<IHttpResponse> GetReleases(string ownerAlias, string repositoryAlias, int? perPage = null, int? page = null) {
        if (string.IsNullOrWhiteSpace(ownerAlias)) throw new ArgumentNullException(nameof(ownerAlias));
        if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
        return await GetReleases(new GitHubGetReleasesOptions(ownerAlias, repositoryAlias, perPage, page));
    }

    /// <summary>
    /// Returns a list of releases of the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#list-releases</cref>
    /// </see>
    public async Task<IHttpResponse> GetReleases(GitHubRepositoryBase repository) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        return await GetReleases(new GitHubGetReleasesOptions(repository));
    }

    /// <summary>
    /// Returns a list of releases of the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="perPage">The maximum amount of collaborators to returned by each page. Default is <c>30</c>. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#list-releases</cref>
    /// </see>
    public async Task<IHttpResponse> GetReleases(GitHubRepositoryBase repository, int? perPage = null, int? page = null) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        return await GetReleases(new GitHubGetReleasesOptions(repository, perPage, page));
    }

    /// <summary>
    /// Returns a list of releases of the repository matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#list-releases</cref>
    /// </see>
    public async Task<IHttpResponse> GetReleases(GitHubGetReleasesOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

}