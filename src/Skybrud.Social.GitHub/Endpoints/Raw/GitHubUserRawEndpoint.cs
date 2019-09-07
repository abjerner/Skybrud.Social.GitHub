using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;

namespace Skybrud.Social.GitHub.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw <strong>User</strong> endpoint.
    /// </summary>
    public class GitHubUserRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal GitHubUserRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetUser() {
            return Client.Get("/user");
        }

        /// <summary>
        /// Gets a list of email addresses of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetEmails() {
            return Client.Get("/user/emails");
        }

        /// <summary>
        /// Gets a list of users following the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetFollowers() {
            return Client.Get("/user/followers");
        }

        /// <summary>
        /// Gets a list of users the authenticated user is following.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetFollowing() {
            return Client.Get("/user/followers");
        }

        /// <summary>
        /// Gets whether the authenticated user is following the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse IsFollowing(string username) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return Client.Get("/user/following/" + username);
        }

        /// <summary>
        /// Gets a list of repositories of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepositories() {
            return Client.Get("/user/repos");
        }

        /// <summary>
        /// Gets a list of organizations the authenticated user is a member of.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetOrganizations() {
            return Client.Get("/user/orgs");
        }

        #endregion

    }

}