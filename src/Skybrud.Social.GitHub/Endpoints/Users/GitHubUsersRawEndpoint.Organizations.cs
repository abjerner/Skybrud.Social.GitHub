using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Users;
using Skybrud.Social.GitHub.Options.Users;

namespace Skybrud.Social.GitHub.Endpoints.Users {

    public partial class GitHubUsersRawEndpoint {

        #region GetOrganizations(...)

        /// <summary>
        /// Gets a list of organizations the user with the specified <paramref name="userId"/> is a member of.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public IHttpResponse GetOrganizations(int userId) {
            return GetOrganizations(new GitHubGetOrganizationsOptions(userId));
        }

        /// <summary>
        /// Gets a list of organizations the user with the specified <paramref name="userId"/> is a member of.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public IHttpResponse GetOrganizations(int userId, int perPage, int page) {
            return GetOrganizations(new GitHubGetOrganizationsOptions(userId, perPage, page));
        }

        /// <summary>
        /// Gets a list of organizations the user with the specified <paramref name="username"/> is a member of.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public IHttpResponse GetOrganizations(string username) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return GetOrganizations(new GitHubGetOrganizationsOptions(username));
        }

        /// <summary>
        /// Gets a list of organizations the user with the specified <paramref name="username"/> is a member of.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public IHttpResponse GetOrganizations(string username, int perPage, int page) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return GetOrganizations(new GitHubGetOrganizationsOptions(username, perPage, page));
        }

        /// <summary>
        /// Gets a list of organizations the specified <paramref name="user"/> is a member of.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public IHttpResponse GetOrganizations(GitHubUserBase user) {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return GetOrganizations(new GitHubGetOrganizationsOptions(user));
        }

        /// <summary>
        /// Gets a list of organizations the specified <paramref name="user"/> is a member of.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public IHttpResponse GetOrganizations(GitHubUserBase user, int perPage, int page) {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return GetOrganizations(new GitHubGetOrganizationsOptions(user, perPage, page));
        }

        /// <summary>
        /// Gets a list of organizations the user matching the specified <paramref name="options"/> is a member of.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
        /// </see>
        public IHttpResponse GetOrganizations(GitHubGetOrganizationsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}