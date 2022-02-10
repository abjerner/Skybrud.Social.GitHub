using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Users;
using Skybrud.Social.GitHub.Options.Repositories;

namespace Skybrud.Social.GitHub.Options.Users {

    /// <summary>
    /// Options for getting the repositories of a GitHub user.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repositories-for-a-user</cref>
    /// </see>
    public class GitHubGetRepositoriesOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the field to be sorted by.
        /// </summary>
        public GitHubRepositorySortField Sort { get; set; }

        /// <summary>
        /// Gets or sets the sort direction of the returned results. Default: when using
        /// <see cref="GitHubRepositorySortField.FullName"/>: <see cref="GitHubSortDirection.Ascending"/>, otherwise
        /// <see cref="GitHubSortDirection.Descending"/>.
        /// </summary>
        public GitHubSortDirection Direction { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of repositories to returned by each page. Maximum is <c>100</c>.
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Gets or sets the page to be returned.
        /// </summary>
        public int Page { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance with default options.
        /// </summary>
        public GitHubGetRepositoriesOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public GitHubGetRepositoriesOptions(int userId) {
            UserId = userId;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="perPage">The maximum amount of repositories to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        public GitHubGetRepositoriesOptions(int userId, int perPage, int page) {
            UserId = userId;
            PerPage = perPage;
            Page = page;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        public GitHubGetRepositoriesOptions(string username) {
            Username = username;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="perPage">The maximum amount of repositories to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        public GitHubGetRepositoriesOptions(string username, int perPage, int page) {
            Username = username;
            PerPage = perPage;
            Page = page;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user">The user.</param>
        public GitHubGetRepositoriesOptions(GitHubUserBase user) {
            if (user == null) throw new ArgumentNullException(nameof(user));
            UserId = user.Id;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="perPage">The maximum amount of repositories to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        public GitHubGetRepositoriesOptions(GitHubUserBase user, int perPage, int page) {
            if (user == null) throw new ArgumentNullException(nameof(user));
            UserId = user.Id;
            PerPage = perPage;
            Page = page;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Make sure we have either a username or a user ID
            if (string.IsNullOrWhiteSpace(Username) && UserId == 0) throw new PropertyNotSetException(nameof(Username));

            // Construct the URL
            string url = string.IsNullOrWhiteSpace(Username) ? $"/user/{UserId}/repos" : $"/users/{Username}/repos";

            // Construct the query string
            IHttpQueryString query = new HttpQueryString();
            if (Sort > 0) query.AddEnumValue("sort", Sort);
            if (Direction > 0) query.AddEnumValue("direction", Direction);
            if (PerPage > 0) query.Add("per_page", PerPage);
            if (Page > 0) query.Add("page", Page);

            // Initialize and configure the request
            return HttpRequest
                .Get(url, query)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}