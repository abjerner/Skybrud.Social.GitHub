using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Users {

    /// <summary>
    /// Options for getting the organizations of a GitHub user.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
    /// </see>
    public class GitHubGetOrganizationsOptions : GitHubHttpRequestOptions {

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
        /// Gets or sets the maximum amount of organizations to returned by each page. Maximum is <c>100</c>.
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
        public GitHubGetOrganizationsOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public GitHubGetOrganizationsOptions(int userId) {
            UserId = userId;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        public GitHubGetOrganizationsOptions(int userId, int perPage, int page) {
            UserId = userId;
            PerPage = perPage;
            Page = page;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        public GitHubGetOrganizationsOptions(string username) {
            Username = username;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        public GitHubGetOrganizationsOptions(string username, int perPage, int page) {
            Username = username;
            PerPage = perPage;
            Page = page;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Make sure we have either a user ID or a username
            if (UserId == 0 && string.IsNullOrWhiteSpace(Username)) throw new PropertyNotSetException(nameof(Username));

            // Construct the URL
            string url = string.IsNullOrWhiteSpace(Username) ? $"/user/{UserId}/orgs" : $"/users/{Username}/orgs";

            // Construct the query string
            IHttpQueryString query = new HttpQueryString();
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