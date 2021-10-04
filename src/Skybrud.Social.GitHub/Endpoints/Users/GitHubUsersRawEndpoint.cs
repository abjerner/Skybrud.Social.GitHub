using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Users;
using System;

namespace Skybrud.Social.GitHub.Endpoints.Users {

    /// <summary>
    /// Class representing the raw <strong>Users</strong> endpoint.
    /// </summary>
    public class GitHubUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal GitHubUsersRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets information about the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetUser(int userId) {
            return GetUser(new GitHubGetUserOptions(userId));
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetUser(string username) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return GetUser(new GitHubGetUserOptions(username));
        }

        /// <summary>
        /// Gets information about the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetUser(GitHubGetUserOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets a list of repositories of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepositories(int userId) {
            return Client.GetResponse(new GitHubGetRepositoriesOptions(userId));
        }

        /// <summary>
        /// Gets a list of repositories of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepositories(string username) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return Client.GetResponse(new GitHubGetRepositoriesOptions(username));
        }

        /// <summary>
        /// Gets a list of repositories of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepositories(GitHubGetRepositoriesOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets a list of organizations the user with the specified <paramref name="userId"/> is a member of.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public IHttpResponse GetOrganizations(int userId) {
            return GetOrganizations(new GitHubGetOrganizationsOptions(userId));
        }

        /// <summary>
        /// Gets a list of organizations the user with the specified <paramref name="username"/> is a member of.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public IHttpResponse GetOrganizations(string username) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return GetOrganizations(new GitHubGetOrganizationsOptions(username));
        }

        /// <summary>
        /// Gets a list of organizations the user matching the specified <paramref name="options"/> is a member of.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public IHttpResponse GetOrganizations(GitHubGetOrganizationsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}