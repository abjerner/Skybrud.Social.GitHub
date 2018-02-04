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

        /// <summary>
        /// Gets or sets the integer ID of the last Organization that you've seen.
        /// </summary>
        public int Since { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of organizations to be returned by each page.
        /// </summary>
        public int PerPage { get; set; }

        #endregion

        #region Constructors
        
        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubGetOrganizationsOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="since"/>.
        /// </summary>
        /// <param name="since">The integer ID of the last organization that you've seen.</param>
        public GitHubGetOrganizationsOptions(int since) {
            Since = since;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Generates an instance of <see cref="IHttpQueryString"/> representing the options.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {

            IHttpQueryString query = new SocialHttpQueryString();

            if (Since > 0) query.Add("since", Since);
            if (PerPage > 0) query.Add("per_page", PerPage);

            return query;

        }

        #endregion

    }

}