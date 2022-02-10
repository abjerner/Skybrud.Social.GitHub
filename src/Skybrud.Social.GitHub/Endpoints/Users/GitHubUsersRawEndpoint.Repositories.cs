using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Users;
using Skybrud.Social.GitHub.Options.Users;

namespace Skybrud.Social.GitHub.Endpoints.Users {

    public partial class GitHubUsersRawEndpoint {

        /// <summary>
        /// Gets a list of repositories of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepositories(int userId) {
            return Client.GetResponse(new GitHubGetRepositoriesOptions(userId));
        }

        /// <summary>
        /// Gets a list of repositories of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="perPage">The maximum amount of repositories to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepositories(int userId, int perPage, int page) {
            return Client.GetResponse(new GitHubGetRepositoriesOptions(userId, perPage, page));
        }

        /// <summary>
        /// Gets a list of repositories of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepositories(string username) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return Client.GetResponse(new GitHubGetRepositoriesOptions(username));
        }

        /// <summary>
        /// Gets a list of repositories of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <param name="perPage">The maximum amount of repositories to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepositories(string username, int perPage, int page) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return Client.GetResponse(new GitHubGetRepositoriesOptions(username, perPage, page));
        }

        /// <summary>
        /// Gets a list of repositories of the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepositories(GitHubUserBase user) {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return Client.GetResponse(new GitHubGetRepositoriesOptions(user));
        }

        /// <summary>
        /// Gets a list of repositories of the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="perPage">The maximum amount of repositories to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepositories(GitHubUserBase user, int perPage, int page) {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return Client.GetResponse(new GitHubGetRepositoriesOptions(user, perPage, page));
        }

        /// <summary>
        /// Gets a list of repositories of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepositories(GitHubGetRepositoriesOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

    }

}