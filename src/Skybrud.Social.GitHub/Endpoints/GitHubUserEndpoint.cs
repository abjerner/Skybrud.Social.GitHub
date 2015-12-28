using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Responses.Emails;
using Skybrud.Social.GitHub.Responses.Followers;
using Skybrud.Social.GitHub.Responses.Organizations;
using Skybrud.Social.GitHub.Responses.Repositories;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints {

    /// <summary>
    /// Class representing the user endpoint.
    /// </summary>
    public class GitHubUserEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubUserRawEndpoint Raw {
            get { return Service.Client.User; }
        }

        #endregion

        #region Constructors

        internal GitHubUserEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <code>GitHubGetUserResponse</code> representing the response.</returns>
        public GitHubGetUserResponse GetUser() {
            return GitHubGetUserResponse.ParseResponse(Raw.GetUser());
        }

        /// <summary>
        /// Gets a list of email addresses of the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <code>GitHubGetEmailsResponse</code> representing the response.</returns>
        public GitHubGetEmailsResponse GetEmails() {
            return GitHubGetEmailsResponse.ParseResponse(Raw.GetEmails());
        }

        /// <summary>
        /// Gets a list of users following the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <code>GitHubGetUsersResponse</code> representing the response.</returns>
        public GitHubGetUsersResponse GetFollowers() {
            return GitHubGetUsersResponse.ParseResponse(Raw.GetFollowers());
        }

        /// <summary>
        /// Gets a list of users the authenticated user is following.
        /// </summary>
        /// <returns>Returns an instance of <code>GitHubGetUsersResponse</code> representing the response.</returns>
        public GitHubGetUsersResponse GetFollowing() {
            return GitHubGetUsersResponse.ParseResponse(Raw.GetFollowing());
        }

        /// <summary>
        /// Gets whether the authenticated user is following the user with the specified <code>username</code>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>Returns an instance of <code>GitHubGetFollowingResponse</code> representing the response.</returns>
        public GitHubGetFollowingResponse IsFollowing(string username) {
            return GitHubGetFollowingResponse.ParseResponse(Raw.IsFollowing(username));
        }

        /// <summary>
        /// Gets a list of repositories of the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <code>GitHubGetRepositoriesResponse</code> representing the response.</returns>
        public GitHubGetRepositoriesResponse GetRepositories() {
            return GitHubGetRepositoriesResponse.ParseResponse(Raw.GetRepositories());
        }

        /// <summary>
        /// Gets a list of organizations the authenticated user is a member of.
        /// </summary>
        /// <returns>Returns an instance of <code>GitHubGetOrganizationsResponse</code> representing the response.</returns>
        public GitHubGetOrganizationsResponse GetOrganizations() {
            return GitHubGetOrganizationsResponse.ParseResponse(Raw.GetOrganizations());
        }

        #endregion
    
    }

}