using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Responses.Emails;
using Skybrud.Social.GitHub.Responses.Followers;
using Skybrud.Social.GitHub.Responses.Organizations;
using Skybrud.Social.GitHub.Responses.Repositories;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints {

    /// <summary>
    /// Class representing the <strong>User</strong> endpoint.
    /// </summary>
    public class GitHubUserEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubUserRawEndpoint Raw => Service.Client.User;

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
        /// <returns>An instance of <see cref="GitHubGetUserResponse"/> representing the response.</returns>
        public GitHubGetUserResponse GetUser() {
            return GitHubGetUserResponse.ParseResponse(Raw.GetUser());
        }

        /// <summary>
        /// Gets a list of email addresses of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubGetEmailsResponse"/> representing the response.</returns>
        public GitHubGetEmailsResponse GetEmails() {
            return GitHubGetEmailsResponse.ParseResponse(Raw.GetEmails());
        }

        /// <summary>
        /// Gets a list of users following the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
        public GitHubUserListResponse GetFollowers() {
            return new GitHubUserListResponse(Raw.GetFollowers());
        }

        /// <summary>
        /// Gets a list of users the authenticated user is following.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
        public GitHubUserListResponse GetFollowing() {
            return new GitHubUserListResponse(Raw.GetFollowing());
        }

        /// <summary>
        /// Gets whether the authenticated user is following the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="GitHubGetFollowingResponse"/> representing the response.</returns>
        public GitHubGetFollowingResponse IsFollowing(string username) {
            return GitHubGetFollowingResponse.ParseResponse(Raw.IsFollowing(username));
        }

        /// <summary>
        /// Gets a list of repositories of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubGetRepositoriesResponse"/> representing the response.</returns>
        public GitHubGetRepositoriesResponse GetRepositories() {
            return GitHubGetRepositoriesResponse.ParseResponse(Raw.GetRepositories());
        }

        /// <summary>
        /// Gets a list of organizations the authenticated user is a member of.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubGetOrganizationsResponse"/> representing the response.</returns>
        public GitHubGetOrganizationsResponse GetOrganizations() {
            return GitHubGetOrganizationsResponse.ParseResponse(Raw.GetOrganizations());
        }

        #endregion
    
    }

}