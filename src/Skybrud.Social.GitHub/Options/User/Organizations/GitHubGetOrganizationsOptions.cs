using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.User.Organizations {
    
    /// <summary>
    /// Options class for getting the organizations of the authenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-the-authenticated-user</cref>
    /// </see>
    public class GitHubGetOrganizationsOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the maximum amount of organizations to returned by each page. Maximum is <c>100</c>.
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Gets or sets the page to fetch. Default is <c>1</c>.
        /// </summary>
        public int Page { get; set; }

        #endregion
        
        #region Constructors

        /// <summary>
        /// Initialize a new instance with default options.
        /// </summary>
        public GitHubGetOrganizationsOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="perPage"/>. and <paramref name="page"/> parameters.
        /// </summary>
        /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        public GitHubGetOrganizationsOptions(int perPage, int page) {
            PerPage = perPage;
            Page = page;
        }

        #endregion

        #region Member methods
        
        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Initialize a new query string
            IHttpQueryString query = new HttpQueryString();

            // Append optional parameters
            if (PerPage > 0) query.Add("per_page", PerPage);
            if (Page > 0) query.Add("page", Page);

            // Initialize and return a new GET request
            return HttpRequest
                .Get("/user/orgs", query)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}