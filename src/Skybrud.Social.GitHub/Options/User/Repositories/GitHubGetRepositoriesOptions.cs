using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Options.Repositories;

namespace Skybrud.Social.GitHub.Options.User.Repositories {
    
    /// <summary>
    /// Options class for getting the repositories of the authenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#list-repositories-for-the-authenticated-user</cref>
    /// </see>
    public class GitHubGetRepositoriesOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the maximum amount of organizations to returned by each page. Maximum is <c>100</c>.
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Gets or sets the page to fetch. Default is <c>1</c>.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the visibility of the repositories that should be returned. Default is
        /// <see cref="GitHubRepositoryVisibility"/>.
        /// </summary>
        public GitHubRepositoryVisibility Visibility { get; set; }

        /// <summary>
        /// Gets or sets the affiliation of the repositories that should be returned. Default is
        /// <see cref="GitHubRepositoryAffiliation.All"/>.
        /// </summary>
        public GitHubRepositoryAffiliation Affiliation { get; set; }

        /// <summary>
        /// Gets or sets the field to be sorted by.
        /// </summary>
        public GitHubRepositorySortField Sort { get; set; }

        /// <summary>
        /// Gets or sets the sort direction of the returned results. Default: when using
        /// <see cref="GitHubRepositorySortField.FullName"/>: <see cref="GitHubSortDirection.Ascending"/>, otherwise
        /// <see cref="GitHubSortDirection.Descending"/>.
        /// </summary>
        public GitHubSortDirection Direction { get; set; }

        #endregion
        
        #region Constructors

        /// <summary>
        /// Initialize a new instance with default options.
        /// </summary>
        public GitHubGetRepositoriesOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="perPage"/> parameter.
        /// </summary>
        /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
        public GitHubGetRepositoriesOptions(int perPage) {
            PerPage = perPage;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="perPage"/> and <paramref name="page"/> parameters.
        /// </summary>
        /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        public GitHubGetRepositoriesOptions(int perPage, int page) {
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
            if (Visibility > 0) query.Add("visibility", GitHubUtils.ToString(Visibility));
            if (Affiliation > 0) query.Add("affiliation", GitHubUtils.ToString(Affiliation));
            if (PerPage > 0) query.Add("per_page", PerPage);
            if (Page > 0) query.Add("page", Page);

            // Initialize and return a new GET request
            return HttpRequest
                .Get("/user/repos", query)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}