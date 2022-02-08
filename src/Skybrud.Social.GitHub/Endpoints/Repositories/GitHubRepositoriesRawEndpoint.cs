using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Branches;
using Skybrud.Social.GitHub.Options.Repositories.Collaborators;
using Skybrud.Social.GitHub.Options.Repositories.Labels;
using Skybrud.Social.GitHub.Options.Repositories.Releases;
using Skybrud.Social.GitHub.Options.Repositories.Tags;
using Skybrud.Social.GitHub.Options.Repositories.Teams;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    /// <summary>
    /// Class representing the raw <strong>Repositories</strong> endpoint.
    /// </summary>
    public partial class GitHubRepositoriesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal GitHubRepositoriesRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the repository matching the specified <paramref name="owner"/> and
        /// <paramref name="repository"/>.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepository(string owner, string repository) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return Client.Get($"/repos/{owner}/{repository}");
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
        public IHttpResponse CreateRepositoryFromTemplate(string templateOwner, string templateRepository, string owner, string name) {
            if (string.IsNullOrWhiteSpace(templateOwner)) throw new ArgumentNullException(nameof(templateOwner));
            if (string.IsNullOrWhiteSpace(templateRepository)) throw new ArgumentNullException(nameof(templateRepository));
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return CreateRepositoryFromTemplate(new GitHubCreateRepositoryFromTemplateOptions(templateOwner, templateRepository, owner, name));
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
        public IHttpResponse CreateRepositoryFromTemplate(string templateOwner, string templateRepository, string owner, string name, bool isPrivate) {
            if (string.IsNullOrWhiteSpace(templateOwner)) throw new ArgumentNullException(nameof(templateOwner));
            if (string.IsNullOrWhiteSpace(templateRepository)) throw new ArgumentNullException(nameof(templateRepository));
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return CreateRepositoryFromTemplate(new GitHubCreateRepositoryFromTemplateOptions(templateOwner, templateRepository, owner, name, isPrivate));
        }

        /// <summary>
        /// Creates a new repository using a repository template.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
        /// </see>
        public IHttpResponse CreateRepositoryFromTemplate(GitHubCreateRepositoryFromTemplateOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Creates a new repository for the authenticated user.
        /// </summary>
        /// <param name="name">The name of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public IHttpResponse CreateUserRepository(string name) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return CreateUserRepository(new GitHubCreateUserRepositoryOptions(name));
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
        public IHttpResponse CreateUserRepository(string name, bool isPrivate) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return CreateUserRepository(new GitHubCreateUserRepositoryOptions(name, isPrivate));
        }

        /// <summary>
        /// Creates a new repository for the authenticated user.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public IHttpResponse CreateUserRepository(GitHubCreateUserRepositoryOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
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
        public IHttpResponse CreateOrganisationRepository(string organisation, string name) {
            if (string.IsNullOrWhiteSpace(organisation)) throw new ArgumentNullException(nameof(organisation));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return CreateOrganisationRepository(new GitHubCreateOrganisationRepositoryOptions(organisation, name));
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
        public IHttpResponse CreateOrganisationRepository(string organisation, string name, bool isPrivate) {
            if (string.IsNullOrWhiteSpace(organisation)) throw new ArgumentNullException(nameof(organisation));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return CreateOrganisationRepository(new GitHubCreateOrganisationRepositoryOptions(organisation, name, isPrivate));
        }

        /// <summary>
        /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public IHttpResponse CreateOrganisationRepository(GitHubCreateOrganisationRepositoryOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Returns a list of teams of the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeams(string owner, string repositoryAlias) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            return Client.GetResponse(new GitHubGetTeamsOptions(owner, repositoryAlias));
        }

        /// <summary>
        /// Returns a list of teams of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeams(GitHubGetTeamsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Returns a list of collaborators of the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetCollaborators(string owner, string repositoryAlias) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            return Client.GetResponse(new GitHubGetCollaboratorsOptions(owner, repositoryAlias));
        }

        /// <summary>
        /// Returns a list of teams of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetCollaborators(GitHubGetCollaboratorsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Returns a list of releases of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="ownerAlias">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetReleases(string ownerAlias, string repositoryAlias) {
            if (string.IsNullOrWhiteSpace(ownerAlias)) throw new ArgumentNullException(nameof(ownerAlias));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            return GetReleases(new GitHubGetReleasesOptions(ownerAlias, repositoryAlias));
        }

        /// <summary>
        /// Returns a list of releases of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="ownerAlias">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="perPage">The maximum amount of collaborators to returned by each page. Default is <c>30</c>. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetReleases(string ownerAlias, string repositoryAlias, int perPage) {
            if (string.IsNullOrWhiteSpace(ownerAlias)) throw new ArgumentNullException(nameof(ownerAlias));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            return GetReleases(new GitHubGetReleasesOptions(ownerAlias, repositoryAlias, perPage));
        }

        /// <summary>
        /// Returns a list of releases of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="ownerAlias">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="perPage">The maximum amount of collaborators to returned by each page. Default is <c>30</c>. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetReleases(string ownerAlias, string repositoryAlias, int perPage, int page) {
            if (string.IsNullOrWhiteSpace(ownerAlias)) throw new ArgumentNullException(nameof(ownerAlias));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            return GetReleases(new GitHubGetReleasesOptions(ownerAlias, repositoryAlias, perPage, page));
        }

        /// <summary>
        /// Returns a list of releases of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetReleases(GitHubGetReleasesOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Returns a list of tags of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="ownerAlias">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTags(string ownerAlias, string repositoryAlias) {
            if (string.IsNullOrWhiteSpace(ownerAlias)) throw new ArgumentNullException(nameof(ownerAlias));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            return GetTags(new GitHubGetTagsOptions(ownerAlias, repositoryAlias));
        }

        /// <summary>
        /// Returns a list of tags of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="ownerAlias">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="perPage">The maximum amount of collaborators to returned by each page. Default is <c>30</c>. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTags(string ownerAlias, string repositoryAlias, int perPage) {
            if (string.IsNullOrWhiteSpace(ownerAlias)) throw new ArgumentNullException(nameof(ownerAlias));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            return GetTags(new GitHubGetTagsOptions(ownerAlias, repositoryAlias, perPage));
        }

        /// <summary>
        /// Returns a list of tags of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="ownerAlias">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="perPage">The maximum amount of collaborators to returned by each page. Default is <c>30</c>. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTags(string ownerAlias, string repositoryAlias, int perPage, int page) {
            if (string.IsNullOrWhiteSpace(ownerAlias)) throw new ArgumentNullException(nameof(ownerAlias));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            return GetTags(new GitHubGetTagsOptions(ownerAlias, repositoryAlias, perPage, page));
        }

        /// <summary>
        /// Returns a list of tags of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTags(GitHubGetTagsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}