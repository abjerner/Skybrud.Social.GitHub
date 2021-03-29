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
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the alias of the organization.
        /// </summary>
        public string Alias { get; set; }

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
        /// <param name="id">The ID of the organization.</param>
        public GitHubGetTeamsOptions(int id) {
            Id = id;
            Page = 1;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="page"/>.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <param name="page">The page to be returned. Default is <c>1</c>, indicating the first page.</param>
        public GitHubGetTeamsOptions(int id, int page) {
            Id = id;
            Page = page;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="page"/> and <paramref name="perPage"/>.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <param name="page">The page to be returned. Default is <c>1</c>, indicating the first page.</param>
        /// <param name="perPage">The maximum amount of pull requests to be returned by each page.</param>
        public GitHubGetTeamsOptions(int id, int page, int perPage) {
            Id = id;
            Page = page;
            PerPage = perPage;
        }

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        /// <param name="alias">The alias/slug of the organization.</param>
        public GitHubGetTeamsOptions(string alias) {
            Alias = alias;
            Page = 1;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="page"/>.
        /// </summary>
        /// <param name="alias">The alias/slug of the organization.</param>
        /// <param name="page">The page to be returned. Default is <c>1</c>, indicating the first page.</param>
        public GitHubGetTeamsOptions(string alias, int page) {
            Alias = alias;
            Page = page;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="page"/> and <paramref name="perPage"/>.
        /// </summary>
        /// <param name="alias">The alias/slug of the organization.</param>
        /// <param name="page">The page to be returned. Default is <c>1</c>, indicating the first page.</param>
        /// <param name="perPage">The maximum amount of pull requests to be returned by each page.</param>
        public GitHubGetTeamsOptions(string alias, int page, int perPage) {
            Alias = alias;
            Page = page;
            PerPage = perPage;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            if (Id == 0 && string.IsNullOrWhiteSpace(Alias)) throw new PropertyNotSetException(nameof(Alias));

            // Determine the URL either from the alias or the ID
            string url = Alias.HasValue() ? $"/orgs/{Alias}/teams" : $"/organizations/{Id}/teams";

            // Construct the query string
            IHttpQueryString query = new HttpQueryString();
            if (Page > 0) query.Add("page", Page);
            if (PerPage > 0) query.Add("per_page", PerPage);

            return HttpRequest.Get(url, query);

        }

        #endregion

    }

}