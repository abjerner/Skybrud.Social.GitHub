using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Repositories;

namespace Skybrud.Social.GitHub.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw <strong>Repositories</strong> endpoint.
    /// </summary>
    public class GitHubRepositoriesRawEndpoint {

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

        #region Methods
        
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

        #endregion

    }

}