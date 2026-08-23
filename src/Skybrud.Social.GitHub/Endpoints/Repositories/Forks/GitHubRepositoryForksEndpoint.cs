using System.Threading.Tasks;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Forks;
using Skybrud.Social.GitHub.Responses.Repositories;

namespace Skybrud.Social.GitHub.Endpoints.Repositories.Forks;

/// <summary>
/// Class representing the <strong>Repositories / Forks</strong> endpoint.
/// </summary>
public class GitHubRepositoryForksEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubRepositoryForksRawEndpoint Raw => Service.Client.Repositories.Forks;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The HTTP service instance.</param>
    public GitHubRepositoryForksEndpoint(GitHubHttpService service) {
        Service = service;
    }

    #endregion

    /// <summary>
    /// Creates a new fork of the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> alias.
    /// </summary>
    /// <param name="owner">The alias of the repository owner.</param>
    /// <param name="repository">The alias/slug of the repository.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateFork(string owner, string repository) {
        return new GitHubRepositoryResponse(await Raw.CreateFork(owner, repository));
    }

    /// <summary>
    /// Creates a new fork of the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> alias.
    /// </summary>
    /// <param name="owner">The alias of the repository owner.</param>
    /// <param name="repository">The alias/slug of the repository.</param>
    /// <param name="organization">The alias of the organization for which the fork will be created.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateFork(string owner, string repository, string organization) {
        return new GitHubRepositoryResponse(await Raw.CreateFork(owner, repository, organization));
    }

    /// <summary>
    /// Creates a new fork of the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateFork(GitHubRepositoryBase repository) {
        return new GitHubRepositoryResponse(await Raw.CreateFork(repository));
    }

    /// <summary>
    /// Creates a new fork of the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="organization">The alias of the organization for which the fork will be created.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateFork(GitHubRepositoryBase repository, string organization) {
        return new GitHubRepositoryResponse(await Raw.CreateFork(repository, organization));
    }

    /// <summary>
    /// Creates a new fork matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateFork(GitHubCreateForkOptions options) {
        return new GitHubRepositoryResponse(await Raw.CreateFork(options));
    }

}