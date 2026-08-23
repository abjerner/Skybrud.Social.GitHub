using System.Threading.Tasks;
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
using Skybrud.Social.GitHub.Options.Repositories;
using Skybrud.Social.GitHub.Responses.Repositories;

namespace Skybrud.Social.GitHub.Endpoints.Repositories;

/// <summary>
/// Class representing the <strong>Repositories</strong> endpoint.
/// </summary>
public class GitHubRepositoriesEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubRepositoriesRawEndpoint Raw => Service.Client.Repositories;

    /// <summary>
    /// Gets a reference to the <strong>Branches</strong> endpoint.
    /// </summary>
    public GitHubRepositoryBranchesEndpoint Branches { get; }

    /// <summary>
    /// Gets a reference to the <strong>Collaborators</strong> endpoint.
    /// </summary>
    public GitHubRepositoryCollaboratorsEndpoint Collaborators { get; }

    /// <summary>
    /// Gets a reference to the <strong>Content</strong> endpoint.
    /// </summary>
    public GitHubRepositoryContentEndpoint Content { get; }

    /// <summary>
    /// Gets a reference to the <strong>Forks</strong> endpoint.
    /// </summary>
    public GitHubRepositoryForksEndpoint Forks { get; }

    /// <summary>
    /// Gets a reference to the <strong>Issues</strong> endpoint.
    /// </summary>
    public GitHubRepositoryIssuesEndpoint Issues { get; }

    /// <summary>
    /// Gets a reference to the <strong>Labels</strong> endpoint.
    /// </summary>
    public GitHubRepositoryLabelsEndpoint Labels { get; }

    /// <summary>
    /// Gets a reference to the <strong>References</strong> endpoint.
    /// </summary>
    public GitHubRepositoryReferencesEndpoint References { get; }

    /// <summary>
    /// Gets a reference to the <strong>Releases</strong> endpoint.
    /// </summary>
    public GitHubRepositoryReleasesEndpoint Releases { get; }

    /// <summary>
    /// Gets a reference to the <strong>Tags</strong> endpoint.
    /// </summary>
    public GitHubRepositoryTagsEndpoint Tags { get; }

    /// <summary>
    /// Gets a reference to the <strong>Teams</strong> endpoint.
    /// </summary>
    public GitHubRepositoryTeamsEndpoint Teams { get; }

    #endregion

    #region Constructors

    internal GitHubRepositoriesEndpoint(GitHubHttpService service) {
        Service = service;
        Branches = new GitHubRepositoryBranchesEndpoint(service);
        Collaborators = new GitHubRepositoryCollaboratorsEndpoint(service);
        Content = new GitHubRepositoryContentEndpoint(service);
        Forks = new GitHubRepositoryForksEndpoint(service);
        Issues = new GitHubRepositoryIssuesEndpoint(service);
        Labels = new GitHubRepositoryLabelsEndpoint(service);
        References = new GitHubRepositoryReferencesEndpoint(service);
        Releases = new GitHubRepositoryReleasesEndpoint(service);
        Tags = new GitHubRepositoryTagsEndpoint(service);
        Teams = new GitHubRepositoryTeamsEndpoint(service);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Gets information about the repository matching the specified <paramref name="owner"/> and
    /// <paramref name="repository"/>.
    /// </summary>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    public async Task<GitHubRepositoryResponse> GetRepository(string owner, string repository) {
        return new GitHubRepositoryResponse(await Raw.GetRepository(owner, repository));
    }

    /// <summary>
    /// Creates a new repository using a repository template.
    /// </summary>
    /// <param name="templateOwner">The alias of the organization or person who owns the template repository.</param>
    /// <param name="templateRepository">The slug of the template repository.</param>
    /// <param name="owner">The organization or person who will own the new repository.</param>
    /// <param name="name">The name of the new repository.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateRepositoryFromTemplate(string templateOwner, string templateRepository, string owner, string name) {
        return new GitHubRepositoryResponse(await Raw.CreateRepositoryFromTemplate(templateOwner, templateRepository, owner, name));
    }

    /// <summary>
    /// Creates a new repository using a repository template.
    /// </summary>
    /// <param name="templateOwner">The alias of the organization or person who owns the template repository.</param>
    /// <param name="templateRepository">The slug of the template repository.</param>
    /// <param name="owner">The organization or person who will own the new repository.</param>
    /// <param name="name">The name of the new repository.</param>
    /// <param name="isPrivate">Whether to create a new private repository.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateRepositoryFromTemplate(string templateOwner, string templateRepository, string owner, string name, bool isPrivate) {
        return new GitHubRepositoryResponse(await Raw.CreateRepositoryFromTemplate(templateOwner, templateRepository, owner, name, isPrivate));
    }

    /// <summary>
    /// Creates a new repository using a repository template.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateRepositoryFromTemplate(GitHubCreateRepositoryFromTemplateOptions options) {
        return new GitHubRepositoryResponse(await Raw.CreateRepositoryFromTemplate(options));
    }

    /// <summary>
    /// Creates a new repository for the authenticated user.
    /// </summary>
    /// <param name="name">The name of the repository.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateUserRepository(string name) {
        return new GitHubRepositoryResponse(await Raw.CreateUserRepository(name));
    }

    /// <summary>
    /// Creates a new repository for the authenticated user.
    /// </summary>
    /// <param name="name">The name of the repository.</param>
    /// <param name="isPrivate">Whether to create a new private repository.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateUserRepository(string name, bool isPrivate) {
        return new GitHubRepositoryResponse(await Raw.CreateUserRepository(name, isPrivate));
    }

    /// <summary>
    /// Creates a new repository for the authenticated user.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateUserRepository(GitHubCreateUserRepositoryOptions options) {
        return new GitHubRepositoryResponse(await Raw.CreateUserRepository(options));
    }

    /// <summary>
    /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
    /// </summary>
    /// <param name="organisation">The organization who will own the new repository.</param>
    /// <param name="name">The name of the repository.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateOrganisationRepository(string organisation, string name) {
        return new GitHubRepositoryResponse(await Raw.CreateOrganisationRepository(organisation, name));
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
    public async Task<GitHubRepositoryResponse> CreateOrganisationRepository(string organisation, string name, bool isPrivate) {
        return new GitHubRepositoryResponse(await Raw.CreateOrganisationRepository(organisation, name, isPrivate));
    }

    /// <summary>
    /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create</cref>
    /// </see>
    public async Task<GitHubRepositoryResponse> CreateOrganisationRepository(GitHubCreateOrganisationRepositoryOptions options) {
        return new GitHubRepositoryResponse(await Raw.CreateOrganisationRepository(options));
    }

    #endregion

}