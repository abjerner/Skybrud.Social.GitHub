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
        public string Organization { get; set; }

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
        /// Initializes a new instance based on the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The alias (username) of the organization.</param>
        public GitHubGetOrganizationMembersOptions(string organization) {
            Organization = organization;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {
            
            if (string.IsNullOrWhiteSpace(Organization)) throw new PropertyNotSetException(nameof(Organization));

            // Initialize a new query string
            IHttpQueryString query = new HttpQueryString();

            // Append optional parameters
            if (Filter != default) query.Add("filter", ToString(Filter));
            if (Role != default) query.Add("role", Role.ToLower());
            if (PerPage > 0) query.Add("per_page", PerPage);
            if (Page > 0) query.Add("page", Page);

            // Initialize and return a new GET request
            return HttpRequest.Get($"/orgs/{Organization}/members", query);

        }

        private string ToString(GitHubMemberFilter filter) {

            switch (filter) {

                case GitHubMemberFilter.TwoFactorDisabled:
                    return "2fa_disabled";

                case GitHubMemberFilter.All:
                    return "all";

                default:
                    return string.Empty;

            }

        }

        #endregion

    }

}