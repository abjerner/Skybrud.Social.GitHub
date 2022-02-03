using Skybrud.Social.GitHub.Options.User.Organizations;
using Skybrud.Social.GitHub.Options.User.Repositories;
using Skybrud.Social.GitHub.Responses.Emails;
using Skybrud.Social.GitHub.Responses.Followers;
using Skybrud.Social.GitHub.Responses.Organizations;
using Skybrud.Social.GitHub.Responses.Repositories;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints.User {

    /// <summary>
    /// Class representing the <strong>User</strong> endpoint.
    /// </summary>
    public class GitHubUserEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubUserRawEndpoint Raw => Service.Client.User;

        #endregion

        #region Constructors

        internal GitHubUserEndpoint(GitHubHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubUserResponse"/> representing the response.</returns>
        public GitHubUserResponse GetUser() {
            return new GitHubUserResponse(Raw.GetUser());
        }

        /// <summary>
        /// Gets a list of email addresses of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubEmailListResponse"/> representing the response.</returns>
        public GitHubEmailListResponse GetEmails() {
            return new GitHubEmailListResponse(Raw.GetEmails());
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
            return new GitHubGetFollowingResponse(Raw.IsFollowing(username));
        }

        /// <summary>
        /// Gets a list of repositories of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
        public GitHubRepositoryListResponse GetRepositories() {
            return new GitHubRepositoryListResponse(Raw.GetRepositories());
        }

        /// <summary>
        /// Gets a list of repositories of the authenticated user.
        /// </summary>
        /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
        public GitHubRepositoryListResponse GetRepositories(int perPage) {
            return new GitHubRepositoryListResponse(Raw.GetRepositories(perPage));
        }

        /// <summary>
        /// Gets a list of repositories of the authenticated user.
        /// </summary>
        /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
        public GitHubRepositoryListResponse GetRepositories(int perPage, int page) {
            return new GitHubRepositoryListResponse(Raw.GetRepositories(perPage, page));
        }

        /// <summary>
        /// Gets a list of repositories of the authenticated user.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
        public GitHubRepositoryListResponse GetRepositories(GitHubGetRepositoriesOptions options) {
            return new GitHubRepositoryListResponse(Raw.GetRepositories(options));
        }

        /// <summary>
        /// Gets a list of organizations the authenticated user is a member of.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-the-authenticated-user</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations() {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations());
        }

        /// <summary>
        /// Returns a list of organizations the authenticated user is a member of.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-the-authenticated-user</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations(GitHubGetOrganizationsOptions options) {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations(options));
        }

        #endregion
    
    }

}