using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Responses.Organizations;
using Skybrud.Social.GitHub.Responses.Repositories;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints {

    /// <summary>
    /// Class representing the <strong>Users</strong> endpoint.
    /// </summary>
    public class GitHubUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubUsersRawEndpoint Raw => Service.Client.Users;

        #endregion

        #region Constructors

        internal GitHubUsersEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="GitHubGetUserResponse"/> representing the response.</returns>
        public GitHubGetUserResponse GetUser(string username) {
            return GitHubGetUserResponse.ParseResponse(Raw.GetUser(username));
        }

        /// <summary>
        /// Gets a list of repositories of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="GitHubGetRepositoriesResponse"/> representing the response.</returns>
        public GitHubGetRepositoriesResponse GetRepositories(string username) {
            return GitHubGetRepositoriesResponse.ParseResponse(Raw.GetRepositories(username));
        }

        /// <summary>
        /// Gets a list of organizations the user with the specified <paramref name="username"/> is a member of.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        public GitHubOrganizationListResponse GetOrganizations(string username) {
            return GitHubOrganizationListResponse.ParseResponse(Raw.GetOrganizations(username));
        }

        #endregion
    
    }

}