using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Repositories.Content;

namespace Skybrud.Social.GitHub.Endpoints.Repositories.Content;

/// <summary>
/// Class representing the raw <strong>Repositories / Content</strong> endpoint.
/// </summary>
public class GitHubRepositoryContentRawEndpoint {

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
    public GitHubRepositoryContentRawEndpoint(GitHubOAuthClient client) {
        Client = client;
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
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
    /// </see>
    public async Task<IHttpResponse> CreateContent(string owner, string repositoryAlias, string path, string message, string content) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));
        if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException(nameof(content));
        return await CreateContent(new GitHubCreateRepositoryContentOptions(owner, repositoryAlias, path, message, content));
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
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
    /// </see>
    public async Task<IHttpResponse> CreateContent(string owner, string repositoryAlias, string path, string message, string content, string? branch) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));
        if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException(nameof(content));
        return await CreateContent(new GitHubCreateRepositoryContentOptions(owner, repositoryAlias, path, message, content, branch));
    }

    /// <summary>
    /// Creates a new file in a repository.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="message">The commit message.</param>
    /// <param name="content">The new file content, using Base64 encoding.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
    /// </see>
    public async Task<IHttpResponse> CreateContent(GitHubRepositoryBase repository, string path, string message, string content) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));
        if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException(nameof(content));
        return await CreateContent(new GitHubCreateRepositoryContentOptions(repository, path, message, content));
    }

    /// <summary>
    /// Creates a new file in a repository.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="message">The commit message.</param>
    /// <param name="content">The new file content, using Base64 encoding.</param>
    /// <param name="branch">The name of the branch name. Uses the default branch if not specified.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
    /// </see>
    public async Task<IHttpResponse> CreateContent(GitHubRepositoryBase repository, string path, string message, string content, string? branch) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));
        if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException(nameof(content));
        return await CreateContent(new GitHubCreateRepositoryContentOptions(repository, path, message, content, branch));
    }

    /// <summary>
    /// Creates a new file in a repository.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
    /// </see>
    public async Task<IHttpResponse> CreateContent(GitHubCreateRepositoryContentOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region GetContent(...)

    /// <summary>
    /// Gets the contents of a file or directory in a repository.
    /// </summary>
    /// <param name="owner">The alias of the user or organization who own the repository.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
    /// </see>
    public async Task<IHttpResponse> GetContent(string owner, string repositoryAlias, string path) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        return await GetContent(new GitHubGetRepositoryContentOptions(owner, repositoryAlias, path));
    }

    /// <summary>
    /// Gets the contents of a file or directory in a repository.
    /// </summary>
    /// <param name="owner">The alias of the user or organization who own the repository.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="ref">The name of the commit/branch/tag.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
    /// </see>
    public async Task<IHttpResponse> GetContent(string owner, string repositoryAlias, string path, string? @ref) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        return await GetContent(new GitHubGetRepositoryContentOptions(owner, repositoryAlias, path, @ref));
    }

    /// <summary>
    /// Gets the contents of a file or directory in a repository.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
    /// </see>
    public async Task<IHttpResponse> GetContent(GitHubRepositoryBase repository, string path) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        return await GetContent(new GitHubGetRepositoryContentOptions(repository, path));
    }

    /// <summary>
    /// Gets the contents of a file or directory in a repository.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="path">The path to the file or directory.</param>
    /// <param name="ref">The name of the commit/branch/tag.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
    /// </see>
    public async Task<IHttpResponse> GetContent(GitHubRepositoryBase repository, string path, string? @ref) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        return await GetContent(new GitHubGetRepositoryContentOptions(repository, path, @ref));
    }

    /// <summary>
    /// Gets the contents of a file or directory in a repository.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
    /// </see>
    public async Task<IHttpResponse> GetContent(GitHubGetRepositoryContentOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region UpdateContent(...)

    /// <summary>
    /// Updates/replaces an existing file in a repository.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
    /// </see>
    public async Task<IHttpResponse> UpdateContent(GitHubUpdateRepositoryContentOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

}