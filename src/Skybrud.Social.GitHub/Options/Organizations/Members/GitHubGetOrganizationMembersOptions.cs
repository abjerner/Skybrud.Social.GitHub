using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Social.GitHub.Options.Organizations.Members {
    
    /// <summary>
    /// Class representing the options for listing the members of a GitHub organization.
    /// </summary>
    public class GitHubGetOrganizationMembersOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias of the organization.
        /// </summary>
        public string OrganizationAlias { get; set; }

        /// <summary>
        /// Gets or sets a filter for the members returned in the list.
        /// </summary>
        public GitHubMemberFilter Filter { get; set; }

        /// <summary>
        /// Gets or sets the role the returned members should match.
        /// </summary>
        public GitHubMemberRole Role { get; set; }

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
        public GitHubGetOrganizationMembersOptions() { }
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias (username) of the organization.</param>
        public GitHubGetOrganizationMembersOptions(string organizationAlias) {
            OrganizationAlias = organizationAlias;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias (username) of the organization.</param>
        /// <param name="perPage">The maximuim amount of results per page (max is <c>100</c>).</param>
        public GitHubGetOrganizationMembersOptions(string organizationAlias, int perPage) {
            OrganizationAlias = organizationAlias;
            PerPage = perPage;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias (username) of the organization.</param>
        /// <param name="perPage">The maximuim amount of results per page (max is <c>100</c>).</param>
        /// <param name="page">The page to fetch.</param>
        public GitHubGetOrganizationMembersOptions(string organizationAlias, int perPage, int page) {
            OrganizationAlias = organizationAlias;
            PerPage = perPage;
            Page = page;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {
            
            if (string.IsNullOrWhiteSpace(OrganizationAlias)) throw new PropertyNotSetException(nameof(OrganizationAlias));

            // Initialize a new query string
            IHttpQueryString query = new HttpQueryString();

            // Append optional parameters
            if (Filter != default) query.Add("filter", GitHubUtils.ToString(Filter));
            if (Role != default) query.Add("role", Role.ToLower());
            if (PerPage > 0) query.Add("per_page", PerPage);
            if (Page > 0) query.Add("page", Page);

            // Initialize and return a new GET request
            return HttpRequest.Get($"/orgs/{OrganizationAlias}/members", query);

        }

        #endregion

    }

}