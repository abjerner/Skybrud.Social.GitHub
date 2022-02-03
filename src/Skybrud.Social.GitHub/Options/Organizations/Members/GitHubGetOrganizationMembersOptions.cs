using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Organizations;

namespace Skybrud.Social.GitHub.Options.Organizations.Members {

    /// <summary>
    /// Class representing the options for listing the members of a GitHub organization.
    /// </summary>
    public class GitHubGetOrganizationMembersOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the organization.
        /// </summary>
        public int OrganizationId { get; set; }

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
        /// Initializes a new instance based on the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        public GitHubGetOrganizationMembersOptions(int organizationId) {
            OrganizationId = organizationId;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="perPage">The maximuim amount of results per page (max is <c>100</c>).</param>
        public GitHubGetOrganizationMembersOptions(int organizationId, int perPage) {
            OrganizationId = organizationId;
            PerPage = perPage;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="perPage">The maximuim amount of results per page (max is <c>100</c>).</param>
        /// <param name="page">The page to fetch.</param>
        public GitHubGetOrganizationMembersOptions(int organizationId, int perPage, int page) {
            OrganizationId = organizationId;
            PerPage = perPage;
            Page = page;
        }

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

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The organization.</param>
        public GitHubGetOrganizationMembersOptions(GitHubOrganizationItem organization) {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            OrganizationAlias = organization.Login;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="perPage">The maximuim amount of results per page (max is <c>100</c>).</param>
        public GitHubGetOrganizationMembersOptions(GitHubOrganizationItem organization, int perPage) {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            OrganizationAlias = organization.Login;
            PerPage = perPage;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="perPage">The maximuim amount of results per page (max is <c>100</c>).</param>
        /// <param name="page">The page to fetch.</param>
        public GitHubGetOrganizationMembersOptions(GitHubOrganizationItem organization, int perPage, int page) {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            OrganizationAlias = organization.Login;
            PerPage = perPage;
            Page = page;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Make sure we have either a organization ID or a alias/login
            if (OrganizationId == 0 && string.IsNullOrWhiteSpace(OrganizationAlias)) throw new PropertyNotSetException(nameof(OrganizationAlias));

            // Construct the URL
            string url = string.IsNullOrWhiteSpace(OrganizationAlias)
                ? $"/organizations/{OrganizationId}/members"
                : $"/orgs/{OrganizationAlias}/members";

            // Initialize and construct the query string
            IHttpQueryString query = new HttpQueryString();
            if (Filter != default) query.Add("filter", GitHubUtils.ToString(Filter));
            if (Role != default) query.Add("role", Role.ToLower());
            if (PerPage > 0) query.Add("per_page", PerPage);
            if (Page > 0) query.Add("page", Page);

            // Initialize the request
            return HttpRequest
                .Get(url, query)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}