using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Responses.Organizations;
using Skybrud.Social.GitHub.Responses.Repositories;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints {

    /// <summary>
    /// Class representing the users endpoint.
    /// </summary>
    public class GitHubUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        #endregion

        #region Constructors

        internal GitHubUsersEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the user with the specified <code>username</code>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>Returns an instance of <code>GitHubGetUserResponse</code> representing the response.</returns>
        public GitHubGetUserResponse GetUser(string username) {
            return GitHubGetUserResponse.ParseResponse(Raw.GetUser(username));
        }

        /// <summary>
        /// Gets a list of repositories of the user with the specified <code>username</code>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>Returns an instance of <code>GitHubGetRepositoriesResponse</code> representing the response.</returns>
        public GitHubGetRepositoriesResponse GetRepositories(string username) {
            return GitHubGetRepositoriesResponse.ParseResponse(Raw.GetRepositories(username));
        }

        /// <summary>
        /// Gets a list of organizations the user with the specified <code>username</code> is a member of.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>Returns an instance of <code>GitHubGetOrganizationsResponse</code> representing the response.</returns>
        public GitHubGetOrganizationsResponse GetOrganizations(string username) {
            return GitHubGetOrganizationsResponse.ParseResponse(Raw.GetOrganizations(username));
        }

        #endregion
    
    }

}