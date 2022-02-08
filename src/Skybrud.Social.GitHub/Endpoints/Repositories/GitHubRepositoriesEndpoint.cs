using System;
using Skybrud.Social.GitHub.Options.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Collaborators;
using Skybrud.Social.GitHub.Options.Repositories.Releases;
using Skybrud.Social.GitHub.Options.Repositories.Tags;
using Skybrud.Social.GitHub.Options.Repositories.Teams;
using Skybrud.Social.GitHub.Responses.Releases;
using Skybrud.Social.GitHub.Responses.Repositories;
using Skybrud.Social.GitHub.Responses.Tags;
using Skybrud.Social.GitHub.Responses.Teams;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    /// <summary>
    /// Class representing the <strong>Repositories</strong> endpoint.
    /// </summary>
    public partial class GitHubRepositoriesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubRepositoriesRawEndpoint Raw => Service.Client.Repositories;

        #endregion

        #region Constructors

        internal GitHubRepositoriesEndpoint(GitHubHttpService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the repository matching the specified <paramref name="owner"/> and
        /// <paramref name="repository"/>.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        public GitHubRepositoryResponse GetRepository(string owner, string repository) {
            return new GitHubRepositoryResponse(Raw.GetRepository(owner, repository));
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
        public GitHubRepositoryResponse CreateRepositoryFromTemplate(string templateOwner, string templateRepository, string owner, string name) {
            return new GitHubRepositoryResponse(Raw.CreateRepositoryFromTemplate(templateOwner, templateRepository, owner, name));
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
        public GitHubRepositoryResponse CreateRepositoryFromTemplate(string templateOwner, string templateRepository, string owner, string name, bool isPrivate) {
            return new GitHubRepositoryResponse(Raw.CreateRepositoryFromTemplate(templateOwner, templateRepository, owner, name, isPrivate));
        }

        /// <summary>
        /// Creates a new repository using a repository template.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instanceo of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
        /// </see>
        public GitHubRepositoryResponse CreateRepositoryFromTemplate(GitHubCreateRepositoryFromTemplateOptions options) {
            return new GitHubRepositoryResponse(Raw.CreateRepositoryFromTemplate(options));
        }

        /// <summary>
        /// Creates a new repository for the authenticated user.
        /// </summary>
        /// <param name="name">The name of the repository.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public GitHubRepositoryResponse CreateUserRepository(string name) {
            return new GitHubRepositoryResponse(Raw.CreateUserRepository(name));
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
        public GitHubRepositoryResponse CreateUserRepository(string name, bool isPrivate) {
            return new GitHubRepositoryResponse(Raw.CreateUserRepository(name, isPrivate));
        }

        /// <summary>
        /// Creates a new repository for the authenticated user.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instanceo of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public GitHubRepositoryResponse CreateUserRepository(GitHubCreateUserRepositoryOptions options) {
            return new GitHubRepositoryResponse(Raw.CreateUserRepository(options));
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
        public GitHubRepositoryResponse CreateOrganisationRepository(string organisation, string name) {
            return new GitHubRepositoryResponse(Raw.CreateOrganisationRepository(organisation, name));
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
        public GitHubRepositoryResponse CreateOrganisationRepository(string organisation, string name, bool isPrivate) {
            return new GitHubRepositoryResponse(Raw.CreateOrganisationRepository(organisation, name, isPrivate));
        }

        /// <summary>
        /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instanceo of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public GitHubRepositoryResponse CreateOrganisationRepository(GitHubCreateOrganisationRepositoryOptions options) {
            return new GitHubRepositoryResponse(Raw.CreateOrganisationRepository(options));
        }

        /// <summary>
        /// Returns a list of releases of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="ownerAlias">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <returns>An instance of <see cref="GitHubReleaseListResponse"/> representing the response.</returns>
        public GitHubReleaseListResponse GetReleases(string ownerAlias, string repositoryAlias) {
            return new GitHubReleaseListResponse(Raw.GetReleases(ownerAlias, repositoryAlias));
        }

        /// <summary>
        /// Returns a list of releases of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="ownerAlias">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="perPage">The maximum amount of collaborators to returned by each page. Default is <c>30</c>. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="GitHubReleaseListResponse"/> representing the response.</returns>
        public GitHubReleaseListResponse GetReleases(string ownerAlias, string repositoryAlias, int perPage) {
            if (string.IsNullOrWhiteSpace(ownerAlias)) throw new ArgumentNullException(nameof(ownerAlias));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            return new GitHubReleaseListResponse(Raw.GetReleases(ownerAlias, repositoryAlias, perPage));
        }

        /// <summary>
        /// Returns a list of releases of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="ownerAlias">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="perPage">The maximum amount of collaborators to returned by each page. Default is <c>30</c>. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="GitHubReleaseListResponse"/> representing the response.</returns>
        public GitHubReleaseListResponse GetReleases(string ownerAlias, string repositoryAlias, int perPage, int page) {
            return new GitHubReleaseListResponse(Raw.GetReleases(ownerAlias, repositoryAlias, perPage, page));
        }

        /// <summary>
        /// Returns a list of releases of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubReleaseListResponse"/> representing the response.</returns>
        public GitHubReleaseListResponse GetReleases(GitHubGetReleasesOptions options) {
            return new GitHubReleaseListResponse(Raw.GetReleases(options));
        }

        /// <summary>
        /// Returns a list of tags of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="ownerAlias">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <returns>An instance of <see cref="GitHubTagListResponse"/> representing the response.</returns>
        public GitHubTagListResponse GetTags(string ownerAlias, string repositoryAlias) {
            return new GitHubTagListResponse(Raw.GetTags(ownerAlias, repositoryAlias));
        }

        /// <summary>
        /// Returns a list of tags of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="ownerAlias">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="perPage">The maximum amount of collaborators to returned by each page. Default is <c>30</c>. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="GitHubTagListResponse"/> representing the response.</returns>
        public GitHubTagListResponse GetTags(string ownerAlias, string repositoryAlias, int perPage) {
            return new GitHubTagListResponse(Raw.GetTags(ownerAlias, repositoryAlias, perPage));
        }

        /// <summary>
        /// Returns a list of tags of the repository matching the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="ownerAlias">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="perPage">The maximum amount of collaborators to returned by each page. Default is <c>30</c>. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="GitHubTagListResponse"/> representing the response.</returns>
        public GitHubTagListResponse GetTags(string ownerAlias, string repositoryAlias, int perPage, int page) {
            return new GitHubTagListResponse(Raw.GetTags(ownerAlias, repositoryAlias, perPage, page));
        }

        /// <summary>
        /// Returns a list of tags of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubTagListResponse"/> representing the response.</returns>
        public GitHubTagListResponse GetTags(GitHubGetTagsOptions options) {
            return new GitHubTagListResponse(Raw.GetTags(options));
        }

        #endregion

    }

}