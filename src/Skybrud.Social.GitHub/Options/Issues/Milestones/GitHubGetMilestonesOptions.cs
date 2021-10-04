using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Issues.Milestones {

    /// <summary>
    /// Options for getting a list of milestones of a GitHub repository.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/issues/milestones/#list-milestones-for-a-repository</cref>
    /// </see>
    public class GitHubGetMilestonesOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the username (login) of the owner of the repository.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets the slug of the repository.
        /// </summary>
        public string Repository { get; set; }

        /// <summary>
        /// Gets or sets the state of the milestones to be returned. Possible values are
        /// <see cref="GitHubMilestoneStateFilter.Open"/> (default), <see cref="GitHubMilestoneStateFilter.Closed"/> and
        /// <see cref="GitHubMilestoneStateFilter.All"/>.
        /// </summary>
        public GitHubMilestoneStateFilter State { get; set; }

        /// <summary>
        /// Gets or sets the field the results should be sorted by. Possible values are
        /// <see cref="GitHubMilestoneSortField.DueOn"/> (default) and
        /// <see cref="GitHubMilestoneSortField.Completeness"/>.
        /// </summary>
        public GitHubMilestoneSortField Sort { get; set; }

        /// <summary>
        /// Gets or sets the direction in which the results should be sorted. Default is <see cref="GitHubSortDirection.Ascending"/>.
        /// </summary>
        public GitHubSortDirection Direction { get; set; }

        /// <summary>
        /// Gets or sets the page to be returned. Default is <c>0</c>, indicating the first page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of events to be returned by each page.
        /// </summary>
        public int PerPage { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubGetMilestonesOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repository"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        public GitHubGetMilestonesOptions(string owner, string repository) {
            Owner = owner;
            Repository = repository;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
        public override IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
            if (string.IsNullOrWhiteSpace(Repository)) throw new PropertyNotSetException(nameof(Repository));

            // Initialzie the query string
            IHttpQueryString query = new HttpQueryString {
                { "state", State.ToUnderscore() },
                { "sort", Sort.ToUnderscore() }
            };

            // Update the query string with additional parameters
            if (Page > 0) query.Add("page", Page);
            if (PerPage > 0) query.Add("per_page", PerPage);
            if (Direction > 0) query.Add("direction", ToString(Direction));

            // Initialize the request
            return HttpRequest
                .Get($"/repos/{Owner}/{Repository}/milestones", query)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}