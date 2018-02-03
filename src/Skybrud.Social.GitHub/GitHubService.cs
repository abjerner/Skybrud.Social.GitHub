using System;
using System.Net;
using Skybrud.Social.GitHub.Endpoints;
using Skybrud.Social.GitHub.OAuth;

namespace Skybrud.Social.GitHub {

    /// <summary>
    /// Class representing the object oriented implementation of the GitHub API.
    /// </summary>
    public class GitHubService {

        #region Properties

        /// <summary>
        /// The internal OAuth client for communication with the GitHub API.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the issues endpoint.
        /// </summary>
        public GitHubIssuesEndpoint Issues { get; }

        /// <summary>
        /// Gets a reference to the organizations endpoint.
        /// </summary>
        public GitHubOrganizationsEndpoint Organizations { get; }

        /// <summary>
        /// Gets a reference to the repositories endpoint.
        /// </summary>
        public GitHubRepositoriesEndpoint Repositories { get; }

        /// <summary>
        /// Gets a reference to the user endpoint.
        /// </summary>
        public GitHubUserEndpoint User { get; }

        /// <summary>
        /// Gets a reference to the users endpoint.
        /// </summary>
        public GitHubUsersEndpoint Users { get; }

        #endregion

        #region Constructors

        private GitHubService(GitHubOAuthClient client) {
            Client = client;
            Issues = new GitHubIssuesEndpoint(this);
            Organizations = new GitHubOrganizationsEndpoint(this);
            Repositories = new GitHubRepositoriesEndpoint(this);
            User = new GitHubUserEndpoint(this);
            Users = new GitHubUsersEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static GitHubService CreateFromOAuthClient(GitHubOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new GitHubService(client);
        }

        /// <summary>
        /// Initializes a new service instance from the specified OAuth 2 <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static GitHubService CreateFromAccessToken(string accessToken) {
            if (String.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            return CreateFromOAuthClient(new GitHubOAuthClient(accessToken));
        }

        /// <summary>
        /// Initializes a new service instance from the specified <paramref name="username"/> and
        /// <paramref name="password"/> using basic authentication in the HTTP protocol. Using this approach is
        /// specific to the GitGub API and not a part of OAuth 2.
        /// </summary>
        /// <param name="username">The username of the user on GitHub.com</param>
        /// <param name="password">The password of the user on GitHub.com</param>
        public static GitHubService CreateFromCredentials(string username, string password) {
            if (String.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            if (String.IsNullOrWhiteSpace(password)) throw new ArgumentNullException(nameof(password));
            return CreateFromOAuthClient(new GitHubOAuthClient {
                Credentials = new NetworkCredential(username, password)
            });
        }

        /// <summary>
        /// Initializes a new service instance from the specified <paramref name="credentials"/> using basic
        /// authentication in the HTTP protocol. Using this approach is specific to the GitGub API and not a part of
        /// OAuth 2.
        /// </summary>
        /// <param name="credentials">The credentials of the user on GitHub.com</param>
        public static GitHubService CreateFromCredentials(NetworkCredential credentials) {
            return CreateFromOAuthClient(new GitHubOAuthClient {
                Credentials = credentials
            });
        }

        #endregion
    
    }

}