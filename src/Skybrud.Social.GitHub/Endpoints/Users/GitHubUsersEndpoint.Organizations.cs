using Skybrud.Social.GitHub.Models.Users;
using Skybrud.Social.GitHub.Options.Users;
using Skybrud.Social.GitHub.Responses.Organizations;

namespace Skybrud.Social.GitHub.Endpoints.Users {

    public partial class GitHubUsersEndpoint {

        /// <summary>
        /// Gets a list of organizations the user with the specified <paramref name="userId"/> is a member of.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations(int userId) {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations(userId));
        }

        /// <summary>
        /// Gets a list of organizations the user with the specified <paramref name="userId"/> is a member of.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations(int userId, int perPage, int page) {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations(userId, perPage, page));
        }

        /// <summary>
        /// Gets a list of organizations the user with the specified <paramref name="username"/> is a member of.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations(string username) {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations(username));
        }

        /// <summary>
        /// Gets a list of organizations the user with the specified <paramref name="username"/> is a member of.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations(string username, int perPage, int page) {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations(username, perPage, page));
        }

        /// <summary>
        /// Gets a list of organizations the specified <paramref name="user"/> is a member of.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations(GitHubUserBase user) {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations(user));
        }

        /// <summary>
        /// Gets a list of organizations the specified <paramref name="user"/> is a member of.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations(GitHubUserBase user, int perPage, int page) {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations(user, perPage, page));
        }

        /// <summary>
        /// Gets a list of organizations the user matching the specified <paramref name="options"/> is a member of.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public GitHubOrganizationListResponse GetOrganizations(GitHubGetOrganizationsOptions options) {
            return new GitHubOrganizationListResponse(Raw.GetOrganizations(options));
        }

    }

}