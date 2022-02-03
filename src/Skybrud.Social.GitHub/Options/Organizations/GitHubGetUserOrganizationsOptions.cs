//using Skybrud.Essentials.Common;
//using Skybrud.Essentials.Http;
//using Skybrud.Essentials.Http.Collections;
//using Skybrud.Social.GitHub.Http;

//namespace Skybrud.Social.GitHub.Options.Organizations {

//    /// <summary>
//    /// Class representing the options for getting a list of organizations for a user identifier by <see cref="Username"/>.
//    /// </summary>
//    /// <see>
//    ///     <cref>https://developer.github.com/v3/orgs/#list-user-organizations</cref>
//    /// </see>
//    public class GitHubGetUserOrganizationsOptions : GitHubHttpRequestOptions {

//        #region Properties

//        /// <summary>
//        /// Gets or sets the username of the user you wish to retrieve organizations for.
//        /// </summary>
//        public string Username { get; set; }

//        /// <summary>
//        /// Gets or sets the page to be returned. Default is <code>0</code>, indicating the first page.
//        /// </summary>
//        public int Page { get; set; }

//        /// <summary>
//        /// Gets or sets the maximum amount of organizations to be returned by each page.
//        /// </summary>
//        public int PerPage { get; set; }

//        #endregion

//        #region Constructors

//        /// <summary>
//        /// Initializes a new instance with default options.
//        /// </summary>
//        public GitHubGetUserOrganizationsOptions() { }

//        /// <summary>
//        /// Initializes a new instance based on the specified <paramref name="username"/>.
//        /// </summary>
//        /// <param name="username"></param>
//        public GitHubGetUserOrganizationsOptions(string username) {
//            Username = username;
//        }

//        /// <summary>
//        /// Initializes a new instance based on the specified <paramref name="username"/> and <paramref name="page"/>.
//        /// </summary>
//        /// <param name="username">The username of the user.</param>
//        /// <param name="page">The page to be returned. Default is <code>0</code>, indicating the first page.</param>
//        public GitHubGetUserOrganizationsOptions(string username, int page) {
//            Username = username;
//            Page = page;
//        }

//        /// <summary>
//        /// Initializes a new instance based on the specified <paramref name="username"/>, <paramref name="page"/> and <paramref name="perPage"/>.
//        /// </summary>
//        /// <param name="username">The username of the user.</param>
//        /// <param name="page">The page to be returned. Default is <code>0</code>, indicating the first page.</param>
//        /// <param name="perPage">The maximum amount of pull requests to be returned by each page.</param>
//        public GitHubGetUserOrganizationsOptions(string username, int page, int perPage) {
//            Username = username;
//            Page = page;
//            PerPage = perPage;
//        }

//        #endregion

//        #region Member methods

//        /// <summary>
//        /// Generates an instance of <see cref="IHttpQueryString"/> representing the options.
//        /// </summary>
//        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
//        public IHttpQueryString GetQueryString() {

//            IHttpQueryString query = new HttpQueryString();
//            if (Page > 0) query.Add("page", Page);
//            if (PerPage > 0) query.Add("per_page", PerPage);

//            return query;

//        }

//        /// <summary>
//        /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
//        /// </summary>
//        /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
//        public override IHttpRequest GetRequest() {

//            // Validate required parameters
//            if (string.IsNullOrWhiteSpace(Username)) throw new PropertyNotSetException(nameof(Username));

//            // Initialize and construct the query string
//            IHttpQueryString query = new HttpQueryString();
//            if (Page > 0) query.Add("page", Page);
//            if (PerPage > 0) query.Add("per_page", PerPage);

//            // Initialize the request
//            return HttpRequest
//                .Get($"/users/{Username}/orgs")
//                .SetAcceptHeader(MediaTypes);

//        }

//        #endregion

//    }

//}