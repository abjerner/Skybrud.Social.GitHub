using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;

namespace Skybrud.Social.GitHub.Endpoints.Raw {

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

        #region Methods

        /// <summary>
        /// Gets information about the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetUser(string username) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return Client.Get($"/users/{username}");
        }

        /// <summary>
        /// Gets a list of repositories of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepositories(string username) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return Client.Get($"/users/{username}/repos");
        }

        /// <summary>
        /// Gets a list of organizations the user with the specified <paramref name="username"/> is a member of.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetOrganizations(string username) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return Client.Get($"/users/{username}/orgs");
        }

        #endregion

    }

}