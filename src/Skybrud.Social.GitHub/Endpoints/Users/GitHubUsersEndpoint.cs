using Skybrud.Social.GitHub.Options.Users;
using Skybrud.Social.GitHub.Responses.Organizations;
using Skybrud.Social.GitHub.Responses.Repositories;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints.Users {

    /// <summary>
    /// Class representing the <strong>Users</strong> endpoint.
    /// </summary>
    public class GitHubUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubUsersRawEndpoint Raw => Service.Client.Users;

        #endregion

        #region Constructors

        internal GitHubUsersEndpoint(GitHubHttpService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="GitHubUserResponse"/> representing the response.</returns>
        public GitHubUserResponse GetUser(int userId) {
            return new GitHubUserResponse(Raw.GetUser(userId));
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="GitHubUserResponse"/> representing the response.</returns>
        public GitHubUserResponse GetUser(string username) {
            return new GitHubUserResponse(Raw.GetUser(username));
        }

        /// <summary>
        /// Gets information about the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubUserResponse"/> representing the response.</returns>
        public GitHubUserResponse GetUser(GitHubGetUserOptions options) {
            return new GitHubUserResponse(Raw.GetUser(options));
        }

        /// <summary>
        /// Gets a list of repositories of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
        public GitHubRepositoryListResponse GetRepositories(int userId) {
            return new GitHubRepositoryListResponse(Raw.GetRepositories(userId));
        }

        /// <summary>
        /// Gets a list of repositories of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
        public GitHubRepositoryListResponse GetRepositories(string username) {
            return new GitHubRepositoryListResponse(Raw.GetRepositories(username));
        }

        /// <summary>
        /// Gets a list of repositories of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
        public GitHubRepositoryListResponse GetRepositories(GitHubGetRepositoriesOptions options) {
            return new GitHubRepositoryListResponse(Raw.GetRepositories(options));
        }

        /// <summary>
        /// Gets a list of organizations the user with the specified <paramref name="userId"/> is a member of.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations(int userId) {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations(userId));
        }

        /// <summary>
        /// Gets a list of organizations the user with the specified <paramref name="username"/> is a member of.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations(string username) {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations(username));
        }

        /// <summary>
        /// Gets a list of organizations the user matching the specified <paramref name="options"/> is a member of.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations(GitHubGetOrganizationsOptions options) {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations(options));
        }

        #endregion

    }

}