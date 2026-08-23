using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Endpoints.Repositories.Branches;
using Skybrud.Social.GitHub.Endpoints.Repositories.Collaborators;
using Skybrud.Social.GitHub.Endpoints.Repositories.Content;
using Skybrud.Social.GitHub.Endpoints.Repositories.Forks;
using Skybrud.Social.GitHub.Endpoints.Repositories.Issues;
using Skybrud.Social.GitHub.Endpoints.Repositories.Labels;
using Skybrud.Social.GitHub.Endpoints.Repositories.References;
using Skybrud.Social.GitHub.Endpoints.Repositories.Releases;
using Skybrud.Social.GitHub.Endpoints.Repositories.Tags;
using Skybrud.Social.GitHub.Endpoints.Repositories.Teams;
using Skybrud.Social.GitHub.Endpoints.Repositories.Topics;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Repositories;

namespace Skybrud.Social.GitHub.Endpoints.Repositories;

/// <summary>
/// Class representing the raw <strong>Repositories</strong> endpoint.
/// </summary>
public class GitHubRepositoriesRawEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent OAuth client.
    /// </summary>
    public GitHubOAuthClient Client { get; }

    /// <summary>
    /// Gets a reference to the <strong>Branches</strong> endpoint.
    /// </summary>
    public GitHubRepositoryBranchesRawEndpoint Branches { get; }

    /// <summary>
    /// Gets a reference to the <strong>Collaborators</strong> endpoint.
    /// </summary>
    public GitHubRepositoryCollaboratorsRawEndpoint Collaborators { get; }

    /// <summary>
    /// Gets a reference to the <strong>Content</strong> endpoint.
    /// </summary>
    public GitHubRepositoryContentRawEndpoint Content { get; }

    /// <summary>
    /// Gets a reference to the <strong>Forks</strong> endpoint.
    /// </summary>
    public GitHubRepositoryForksRawEndpoint Forks { get; }

    /// <summary>
    /// Gets a reference to the <strong>Issues</strong> endpoint.
    /// </summary>
    public GitHubRepositoryIssuesRawEndpoint Issues { get; }

    /// <summary>
    /// Gets a reference to the <strong>Labels</strong> endpoint.
    /// </summary>
    public GitHubRepositoryLabelsRawEndpoint Labels { get; }

    /// <summary>
    /// Gets a reference to the <strong>References</strong> endpoint.
    /// </summary>
    public GitHubRepositoryReferencesRawEndpoint References { get; }

    /// <summary>
    /// Gets a reference to the <strong>Releases</strong> endpoint.
    /// </summary>
    public GitHubRepositoryReleasesRawEndpoint Releases { get; }

    /// <summary>
    /// Gets a reference to the <strong>Tags</strong> endpoint.
    /// </summary>
    public GitHubRepositoryRawEndpoint Tags { get; }

    /// <summary>
    /// Gets a reference to the <strong>Teams</strong> endpoint.
    /// </summary>
    public GitHubRepositoryTeamsRawEndpoint Teams { get; }

    /// <summary>
    /// Gets a reference to the <strong>Topics</strong> endpoint.
    /// </summary>
    public GitHubRepositoryTopicsRawEndpoint Topics { get; }

    #endregion

    #region Constructors

    internal GitHubRepositoriesRawEndpoint(GitHubOAuthClient client) {
        Client = client;
        Branches = new GitHubRepositoryBranchesRawEndpoint(client);
        Collaborators = new GitHubRepositoryCollaboratorsRawEndpoint(client);
        Content = new GitHubRepositoryContentRawEndpoint(client);
        Forks = new GitHubRepositoryForksRawEndpoint(client);
        Issues = new GitHubRepositoryIssuesRawEndpoint(client);
        Labels = new GitHubRepositoryLabelsRawEndpoint(client);
        References = new GitHubRepositoryReferencesRawEndpoint(client);
        Releases = new GitHubRepositoryReleasesRawEndpoint(client);
        Tags = new GitHubRepositoryRawEndpoint(client);
        Teams = new GitHubRepositoryTeamsRawEndpoint(client);
        Topics = new GitHubRepositoryTopicsRawEndpoint(client);
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Gets information about the repository matching the specified <paramref name="owner"/> and
    /// <paramref name="repository"/>.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetRepository(string owner, string repository) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
        return await Client.GetAsync($"/repos/{owner}/{repository}");
    }

    /// <summary>
    /// Creates a new repository using a repository template.
    /// </summary>
    /// <param name="templateOwner">The alias of the organization or person who owns the template repository.</param>
    /// <param name="templateRepository">The slug of the template repository.</param>
    /// <param name="owner">The organization or person who will own the new repository.</param>
    /// <param name="name">The name of the new repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
    /// </see>
    public async Task<IHttpResponse> CreateRepositoryFromTemplate(string templateOwner, string templateRepository, string owner, string name) {
        if (string.IsNullOrWhiteSpace(templateOwner)) throw new ArgumentNullException(nameof(templateOwner));
        if (string.IsNullOrWhiteSpace(templateRepository)) throw new ArgumentNullException(nameof(templateRepository));
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return await CreateRepositoryFromTemplate(new GitHubCreateRepositoryFromTemplateOptions(templateOwner, templateRepository, owner, name));
    }

    /// <summary>
    /// Creates a new repository using a repository template.
    /// </summary>
    /// <param name="templateOwner">The alias of the organization or person who owns the template repository.</param>
    /// <param name="templateRepository">The slug of the template repository.</param>
    /// <param name="owner">The organization or person who will own the new repository.</param>
    /// <param name="name">The name of the new repository.</param>
    /// <param name="isPrivate">Whether to create a new private repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
    /// </see>
    public async Task<IHttpResponse> CreateRepositoryFromTemplate(string templateOwner, string templateRepository, string owner, string name, bool isPrivate) {
        if (string.IsNullOrWhiteSpace(templateOwner)) throw new ArgumentNullException(nameof(templateOwner));
        if (string.IsNullOrWhiteSpace(templateRepository)) throw new ArgumentNullException(nameof(templateRepository));
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return await CreateRepositoryFromTemplate(new GitHubCreateRepositoryFromTemplateOptions(templateOwner, templateRepository, owner, name, isPrivate));
    }

    /// <summary>
    /// Creates a new repository using a repository template.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
    /// </see>
    public async Task<IHttpResponse> CreateRepositoryFromTemplate(GitHubCreateRepositoryFromTemplateOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    /// <summary>
    /// Creates a new repository for the authenticated user.
    /// </summary>
    /// <param name="name">The name of the repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<IHttpResponse> CreateUserRepository(string name) {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return await CreateUserRepository(new GitHubCreateUserRepositoryOptions(name));
    }

    /// <summary>
    /// Creates a new repository for the authenticated user.
    /// </summary>
    /// <param name="name">The name of the repository.</param>
    /// <param name="isPrivate">Whether to create a new private repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<IHttpResponse> CreateUserRepository(string name, bool isPrivate) {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return await CreateUserRepository(new GitHubCreateUserRepositoryOptions(name, isPrivate));
    }

    /// <summary>
    /// Creates a new repository for the authenticated user.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<IHttpResponse> CreateUserRepository(GitHubCreateUserRepositoryOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    /// <summary>
    /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
    /// </summary>
    /// <param name="organisation">The organization who will own the new repository.</param>
    /// <param name="name">The name of the repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<IHttpResponse> CreateOrganisationRepository(string organisation, string name) {
        if (string.IsNullOrWhiteSpace(organisation)) throw new ArgumentNullException(nameof(organisation));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return await CreateOrganisationRepository(new GitHubCreateOrganisationRepositoryOptions(organisation, name));
    }

    /// <summary>
    /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
    /// </summary>
    /// <param name="organisation">The organization who will own the new repository.</param>
    /// <param name="name">The name of the repository.</param>
    /// <param name="isPrivate">Whether to create a new private repository.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<IHttpResponse> CreateOrganisationRepository(string organisation, string name, bool isPrivate) {
        if (string.IsNullOrWhiteSpace(organisation)) throw new ArgumentNullException(nameof(organisation));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return await CreateOrganisationRepository(new GitHubCreateOrganisationRepositoryOptions(organisation, name, isPrivate));
    }

    /// <summary>
    /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<IHttpResponse> CreateOrganisationRepository(GitHubCreateOrganisationRepositoryOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

}