using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.Http;

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
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetUser() {
            return Client.DoHttpGetRequest("/user");
        }

        /// <summary>
        /// Gets a list of email addresses of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetEmails() {
            return Client.DoHttpGetRequest("/user/emails");
        }

        /// <summary>
        /// Gets a list of users following the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetFollowers() {
            return Client.DoHttpGetRequest("/user/followers");
        }

        /// <summary>
        /// Gets a list of users the authenticated user is following.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetFollowing() {
            return Client.DoHttpGetRequest("/user/followers");
        }

        /// <summary>
        /// Gets whether the authenticated user is following the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse IsFollowing(string username) {
            return Client.DoHttpGetRequest("/user/following/" + username);
        }

        /// <summary>
        /// Gets a list of repositories of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetRepositories() {
            return Client.DoHttpGetRequest("/user/repos");
        }

        /// <summary>
        /// Gets a list of organizations the authenticated user is a member of.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetOrganizations() {
            return Client.DoHttpGetRequest("/user/orgs");
        }

        #endregion

    }

}