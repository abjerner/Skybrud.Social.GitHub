using System.Threading.Tasks;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Content;
using Skybrud.Social.GitHub.Responses.Repositories.Content;

namespace Skybrud.Social.GitHub.Endpoints.Repositories.Content;

/// <summary>
/// Class representing the <strong>Repositories / Content</strong> endpoint.
/// </summary>
public class GitHubRepositoryContentEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubRepositoryContentRawEndpoint Raw => Service.Client.Repositories.Content;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The HTTP service instance.</param>
    public GitHubRepositoryContentEndpoint(GitHubHttpService service) {
        Service = service;
    }

    #endregion

    #region CreateContent(...)

    /// <summary>
    /// Creates a new file in a repository.
    /// </summary>
    /// <param name="owner">The alias of the user or organization who own the repository.</param>
    /// <param name="repositoryAlias">The options for the request to the API.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="message">The commit message.</param>
    /// <param name="content">The new file content, using Base64 encoding.</param>
    /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
    /// </see>
    public async Task<GitHubContentResponse> CreateContent(string owner, string repositoryAlias, string path, string message, string content) {
        return new GitHubContentResponse(await Raw.CreateContent(owner, repositoryAlias, path, message, content));
    }

    /// <summary>
    /// Creates a new file in a repository.
    /// </summary>
    /// <param name="owner">The alias of the user or organization who own the repository.</param>
    /// <param name="repositoryAlias">The options for the request to the API.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="message">The commit message.</param>
    /// <param name="content">The new file content, using Base64 encoding.</param>
    /// <param name="branch">The name of the branch name. Uses the default branch if not specified.</param>
    /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
    /// </see>
    public async Task<GitHubContentResponse> CreateContent(string owner, string repositoryAlias, string path, string message, string content, string? branch) {
        return new GitHubContentResponse(await Raw.CreateContent(owner, repositoryAlias, path, message, content, branch));
    }

    /// <summary>
    /// Creates a new file in a repository.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="message">The commit message.</param>
    /// <param name="content">The new file content, using Base64 encoding.</param>
    /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
    /// </see>
    public async Task<GitHubContentResponse> CreateContent(GitHubRepositoryBase repository, string path, string message, string content) {
        return new GitHubContentResponse(await Raw.CreateContent(repository, path, message, content));
    }

    /// <summary>
    /// Creates a new file in a repository.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="message">The commit message.</param>
    /// <param name="content">The new file content, using Base64 encoding.</param>
    /// <param name="branch">The name of the branch name. Uses the default branch if not specified.</param>
    /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
    /// </see>
    public async Task<GitHubContentResponse> CreateContent(GitHubRepositoryBase repository, string path, string message, string content, string? branch) {
        return new GitHubContentResponse(await Raw.CreateContent(repository, path, message, content, branch));
    }

    /// <summary>
    /// Creates a new file in a repository.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
    /// </see>
    public async Task<GitHubContentResponse> CreateContent(GitHubCreateRepositoryContentOptions options) {
        return new GitHubContentResponse(await Raw.CreateContent(options));
    }

    #endregion

    #region GetContent(...)

    /// <summary>
    /// Gets the contents of a file or directory in a repository.
    /// </summary>
    /// <param name="owner">The alias of the user or organization who own the repository.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
    /// </see>
    public async Task<GitHubContentResponse> GetContent(string owner, string repositoryAlias, string path) {
        return new GitHubContentResponse(await Raw.GetContent(owner, repositoryAlias, path));
    }

    /// <summary>
    /// Gets the contents of a file or directory in a repository.
    /// </summary>
    /// <param name="owner">The alias of the user or organization who own the repository.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="ref">The name of the commit/branch/tag.</param>
    /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
    /// </see>
    public async Task<GitHubContentResponse> GetContent(string owner, string repositoryAlias, string path, string? @ref) {
        return new GitHubContentResponse(await Raw.GetContent(owner, repositoryAlias, path, @ref));
    }

    /// <summary>
    /// Gets the contents of a file or directory in a repository.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
    /// </see>
    public async Task<GitHubContentResponse> GetContent(GitHubRepositoryBase repository, string path) {
        return new GitHubContentResponse(await Raw.GetContent(repository, path));
    }

    /// <summary>
    /// Gets the contents of a file or directory in a repository.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="ref">The name of the commit/branch/tag.</param>
    /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
    /// </see>
    public async Task<GitHubContentResponse> GetContent(GitHubRepositoryBase repository, string path, string? @ref) {
        return new GitHubContentResponse(await Raw.GetContent(repository, path, @ref));
    }

    /// <summary>
    /// Gets the contents of a file or directory in a repository.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
    /// </see>
    public async Task<GitHubContentResponse> GetContent(GitHubGetRepositoryContentOptions options) {
        return new GitHubContentResponse(await Raw.GetContent(options));
    }

    #endregion

    #region UpdateContent(...)

    /// <summary>
    /// Updates/replaces an existing file in a repository.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
    /// </see>
    public async Task<GitHubContentResponse> UpdateContent(GitHubUpdateRepositoryContentOptions options) {
        return new GitHubContentResponse(await Raw.UpdateContent(options));
    }

    #endregion

}