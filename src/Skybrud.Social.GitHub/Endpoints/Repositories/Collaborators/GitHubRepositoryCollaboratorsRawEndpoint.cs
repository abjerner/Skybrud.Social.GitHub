using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Models.Users;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Repositories.Collaborators;

namespace Skybrud.Social.GitHub.Endpoints.Repositories.Collaborators;

/// <summary>
/// Class representing the raw <strong>Repositories / Collaborators</strong> endpoint.
/// </summary>
public class GitHubRepositoryCollaboratorsRawEndpoint {

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
    public GitHubRepositoryCollaboratorsRawEndpoint(GitHubOAuthClient client) {
        Client = client;
    }

    #endregion

    #region AddCollaborator(...)

    /// <summary>
    /// Adds the user with <paramref name="username"/> as a collaborator to the repository matching the specified
    /// <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="owner">The alias of the repository owner.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="username">The username of the user to be added as a collaborator.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/collaborators#add-a-repository-collaborator</cref>
    /// </see>
    public async Task<IHttpResponse> AddCollaborator(string owner, string repositoryAlias, string username) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
        if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
        return await AddCollaborator(new GitHubAddCollaboratorOptions(owner, repositoryAlias, username));
    }

    /// <summary>
    /// Adds the user with <paramref name="username"/> as a collaborator to <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="username">The username of the user to be added as a collaborator.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/collaborators#add-a-repository-collaborator</cref>
    /// </see>
    public async Task<IHttpResponse> AddCollaborator(GitHubRepositoryBase repository, string username) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
        return await AddCollaborator(new GitHubAddCollaboratorOptions(repository, username));
    }

    /// <summary>
    /// Adda <paramref name="user"/> as a collaborator to the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="user">The user to be added as a collaborator.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/collaborators#add-a-repository-collaborator</cref>
    /// </see>
    public async Task<IHttpResponse> AddCollaborator(GitHubRepositoryBase repository, GitHubUserBase user) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        if (user == null) throw new ArgumentNullException(nameof(user));
        return await AddCollaborator(new GitHubAddCollaboratorOptions(repository, user));
    }

    /// <summary>
    /// Adda a new collaborator to the repository matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/collaborators#add-a-repository-collaborator</cref>
    /// </see>
    public async Task<IHttpResponse> AddCollaborator(GitHubAddCollaboratorOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region GetCollaborators(...)

    /// <summary>
    /// Returns a list of collaborators of the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="owner">The username of the parent user or organization.</param>
    /// <param name="repositoryAlias">The alias of the repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/collaborators#list-repository-collaborators</cref>
    /// </see>
    public async Task<IHttpResponse> GetCollaborators(string owner, string repositoryAlias) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
        return await Client.GetResponseAsync(new GitHubGetCollaboratorsOptions(owner, repositoryAlias));
    }

    /// <summary>
    /// Returns a list of collaborators of the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="owner">The username of the parent user or organization.</param>
    /// <param name="repositoryAlias">The alias of the repository.</param>
    /// <param name="perPage">The maximum amount of collaborators to returned by each page.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/collaborators#list-repository-collaborators</cref>
    /// </see>
    public async Task<IHttpResponse> GetCollaborators(string owner, string repositoryAlias, int? perPage = null, int? page = null) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
        return await Client.GetResponseAsync(new GitHubGetCollaboratorsOptions(owner, repositoryAlias, perPage, page));
    }

    /// <summary>
    /// Returns a list of collaborators of the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/collaborators#list-repository-collaborators</cref>
    /// </see>
    public async Task<IHttpResponse> GetCollaborators(GitHubRepositoryBase repository) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        return await Client.GetResponseAsync(new GitHubGetCollaboratorsOptions(repository));
    }

    /// <summary>
    /// Returns a list of collaborators of the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="perPage">The maximum amount of collaborators to returned by each page.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/collaborators#list-repository-collaborators</cref>
    /// </see>
    public async Task<IHttpResponse> GetCollaborators(GitHubRepositoryBase repository, int? perPage = null, int? page = null) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        return await Client.GetResponseAsync(new GitHubGetCollaboratorsOptions(repository, perPage, page));
    }

    /// <summary>
    /// Returns a list of teams of the repository matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/collaborators#list-repository-collaborators</cref>
    /// </see>
    public async Task<IHttpResponse> GetCollaborators(GitHubGetCollaboratorsOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

}