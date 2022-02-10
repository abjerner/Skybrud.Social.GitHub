using Skybrud.Social.GitHub.Options.Users;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints.Users {

    /// <summary>
    /// Class representing the <strong>Users</strong> endpoint.
    /// </summary>
    public partial class GitHubUsersEndpoint {

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

        #endregion

    }

}