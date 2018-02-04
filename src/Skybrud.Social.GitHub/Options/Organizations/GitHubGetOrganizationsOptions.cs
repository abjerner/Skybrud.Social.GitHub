using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.GitHub.Options.Organizations {

    /// <summary>
    /// Class representing the options for getting a list of organizations of the authenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/orgs/#list-your-organizations</cref>
    /// </see>
    public class GitHubGetOrganizationsOptions : IHttpGetOptions {

        #region Properties

        ///// <summary>
        ///// Gets or sets the integer ID of the last Organization that you've seen.
        ///// </summary>
        //public int Since { get; set; }

        /// <summary>
        /// Gets or sets the page to be returned. Default is <code>1</code>, indicating the first page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of organizations to be returned by each page.
        /// </summary>
        public int PerPage { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubGetOrganizationsOptions() {
            Page = 1;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="page"/>.
        /// </summary>
        /// <param name="page">The page to be returned. Default is <code>1</code>, indicating the first page.</param>
        public GitHubGetOrganizationsOptions(int page) {
            Page = page;
        }
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="page"/> and <paramref name="perPage"/>.
        /// </summary>
        /// <param name="page">The page to be returned. Default is <code>1</code>, indicating the first page.</param>
        /// <param name="perPage">The maximum amount of pull requests to be returned by each page.</param>
        public GitHubGetOrganizationsOptions(int page, int perPage) {
            Page = page;
            PerPage = perPage;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Generates an instance of <see cref="IHttpQueryString"/> representing the options.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {

            IHttpQueryString query = new SocialHttpQueryString();

            //if (Since > 0) query.Add("since", Since);
            if (Page > 0) query.Add("page", Page);
            if (PerPage > 0) query.Add("per_page", PerPage);

            return query;

        }

        #endregion

    }

}