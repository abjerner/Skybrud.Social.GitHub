using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Options.Organizations.Members;

namespace Skybrud.Social.GitHub.Options.Organizations.OutsideCollaborators {
    
    /// <summary>
    /// Options for getting a list of outside collaborators of a GitHub organization.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-outside-collaborators-for-an-organization</cref>
    /// </see>
    public class GitHubGetOutsideCollaboratorsOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias of the organization.
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// Gets or sets a filter for the users returned in the list.
        /// </summary>
        public GitHubMemberFilter Filter { get; set; }

        /// <summary>
        /// Gets or sets the maximuim amount of results per page (max is <c>100</c>).
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Gets or sets the page to fetch.
        /// </summary>
        public int Page { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instacne with default options.
        /// </summary>
        public GitHubGetOutsideCollaboratorsOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The alias (username) of the organization.</param>
        public GitHubGetOutsideCollaboratorsOptions(string organization) {
            Organization = organization;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The alias (username) of the organization.</param>
        /// <param name="perPage">The maximuim amount of results per page (max is <c>100</c>).</param>
        public GitHubGetOutsideCollaboratorsOptions(string organization, int perPage) {
            Organization = organization;
            PerPage = perPage;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The alias (username) of the organization.</param>
        /// <param name="perPage">The maximuim amount of results per page (max is <c>100</c>).</param>
        /// <param name="page">The page to fetch.</param>
        public GitHubGetOutsideCollaboratorsOptions(string organization, int perPage, int page) {
            Organization = organization;
            PerPage = perPage;
            Page = page;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {
            
            // Validate required parameters
            if (string.IsNullOrWhiteSpace(Organization)) throw new PropertyNotSetException(nameof(Organization));
            
            // Initialize and construct the query string
            IHttpQueryString query = new HttpQueryString();
            if (Filter != default) query.Add("filter", GitHubUtils.ToString(Filter));
            if (PerPage > 0) query.Add("per_page", PerPage);
            if (Page > 0) query.Add("page", Page);
            
            // Initialize the request
            return HttpRequest
                .Get($"/orgs/{Organization}/outside_collaborators", query)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}