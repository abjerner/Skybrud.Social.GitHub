using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Social.GitHub.Options.Organizations.Teams {
    
    /// <summary>
    /// Class representing the options for getting a list of team of a GitHub organization.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/orgs/#list-your-organizations</cref>
    /// </see>
    public class GitHubGetTeamsOptions : IHttpRequestOptions {

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
        /// Gets or sets the page to be returned. Default is <c>1</c>, indicating the first page.
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
        public GitHubGetTeamsOptions() {
            Page = 1;
        }

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        public GitHubGetTeamsOptions(int organizationId) {
            OrganizationId = organizationId;
            Page = 1;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="page"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="page">The page to be returned. Default is <c>1</c>, indicating the first page.</param>
        public GitHubGetTeamsOptions(int organizationId, int page) {
            OrganizationId = organizationId;
            Page = page;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="page"/> and <paramref name="perPage"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="page">The page to be returned. Default is <c>1</c>, indicating the first page.</param>
        /// <param name="perPage">The maximum amount of pull requests to be returned by each page.</param>
        public GitHubGetTeamsOptions(int organizationId, int page, int perPage) {
            OrganizationId = organizationId;
            Page = page;
            PerPage = perPage;
        }

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        /// <param name="organizationAlias">The alias/slug of the organization.</param>
        public GitHubGetTeamsOptions(string organizationAlias) {
            OrganizationAlias = organizationAlias;
            Page = 1;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="page"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias/slug of the organization.</param>
        /// <param name="page">The page to be returned. Default is <c>1</c>, indicating the first page.</param>
        public GitHubGetTeamsOptions(string organizationAlias, int page) {
            OrganizationAlias = organizationAlias;
            Page = page;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="page"/> and <paramref name="perPage"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias/slug of the organization.</param>
        /// <param name="page">The page to be returned. Default is <c>1</c>, indicating the first page.</param>
        /// <param name="perPage">The maximum amount of pull requests to be returned by each page.</param>
        public GitHubGetTeamsOptions(string organizationAlias, int page, int perPage) {
            OrganizationAlias = organizationAlias;
            Page = page;
            PerPage = perPage;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            if (OrganizationId == 0 && string.IsNullOrWhiteSpace(OrganizationAlias)) throw new PropertyNotSetException(nameof(OrganizationAlias));

            // Determine the URL either from the alias or the ID
            string url = OrganizationAlias.HasValue() ? $"/orgs/{OrganizationAlias}/teams" : $"/organizations/{OrganizationId}/teams";

            // Construct the query string
            IHttpQueryString query = new HttpQueryString();
            if (Page > 0) query.Add("page", Page);
            if (PerPage > 0) query.Add("per_page", PerPage);

            return HttpRequest.Get(url, query);

        }

        #endregion

    }

}