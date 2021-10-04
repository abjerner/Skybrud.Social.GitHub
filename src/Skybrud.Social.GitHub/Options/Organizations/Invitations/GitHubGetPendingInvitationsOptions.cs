using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Organizations;
using System;

namespace Skybrud.Social.GitHub.Options.Organizations.Invitations {
    
    /// <summary>
    /// Class with options for getting a list of pending invitations of a GitHub organization.
    /// </summary>
    public class GitHubGetPendingInvitationsOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias/slug of the organization.
        /// </summary>
        public string OrganizationAlias { get; set; }

        /// <summary>
        /// Gets or sets the page to be returned. Default is <c>1</c>, indicating the first page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of invites to be returned by each page. Default is <c>30</c>. Max is <c>100</c>.
        /// </summary>
        public int PerPage { get; set; }

        #endregion

        #region Constructors
        
        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubGetPendingInvitationsOptions() { }
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias of the organization.</param>
        public GitHubGetPendingInvitationsOptions(string organizationAlias) {
            OrganizationAlias = organizationAlias;
        }
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias of the organization.</param>
        /// <param name="perPage">The page to be returned.</param>
        public GitHubGetPendingInvitationsOptions(string organizationAlias, int perPage) {
            OrganizationAlias = organizationAlias;
            PerPage = perPage;
        }
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The organization.</param>
        public GitHubGetPendingInvitationsOptions(GitHubOrganizationItem organization) {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            OrganizationAlias = organization.Login;
        }
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="perPage">The page to be returned.</param>
        public GitHubGetPendingInvitationsOptions(GitHubOrganizationItem organization, int perPage) {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            OrganizationAlias = organization.Login;
            PerPage = perPage;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {
            
            // Validate required parameters
            if (string.IsNullOrWhiteSpace(OrganizationAlias)) throw new PropertyNotSetException(nameof(OrganizationAlias));
            
            // Initialize and construct the query string
            IHttpQueryString query = new HttpQueryString();
            if (PerPage > 0) query.Add("per_page", PerPage);
            if (Page > 0) query.Add("page", Page);
            
            // Initialize the request
            return HttpRequest
                .Get($"/orgs/{OrganizationAlias}/invitations", query)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}