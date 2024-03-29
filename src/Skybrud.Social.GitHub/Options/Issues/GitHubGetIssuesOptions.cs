using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Issues {

    /// <summary>
    /// Class representing the options for getting a list of issues.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/issues/#list-issues</cref>
    /// </see>
    public class GitHubGetIssuesOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Indicates which sorts of issues to return. Default is <see cref="GitHubIssueFilter.Assigned"/>.
        /// </summary>
        public GitHubIssueFilter Filter { get; set; }

        /// <summary>
        /// Indicates the state of the issues to return. Default is <see cref="GitHubIssueState.Open"/>.
        /// </summary>
        public GitHubIssueState State { get; set; }

        /// <summary>
        /// A list of label names the returned issues should match.
        /// </summary>
        public string[] Labels { get; set; }

        /// <summary>
        /// What to sort results by. Default is <see cref="GitHubIssueSortField.Created"/>.
        /// </summary>
        public GitHubIssueSortField Sort { get; set; }

        /// <summary>
        /// The direction of the sort. Default is <see cref="GitHubSortDirection.Descending"/>.
        /// </summary>
        public GitHubSortDirection Direction { get; set; }

        /// <summary>
        /// Only issues updated at or after this time are returned. Default is <code>null</code>.
        /// </summary>
        public EssentialsTime Since { get; set; }

        /// <summary>
        /// Gets or sets the page to be returned.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of issues to be returned by each page.
        /// </summary>
        public int PerPage { get; set; }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Initialzie the query string
            IHttpQueryString query = new HttpQueryString {
                {"filter", StringUtils.ToLower(Filter)},
                {"state", StringUtils.ToLower(State)}
            };

            // Update the query string with additional parameters
            if (Labels != null && Labels.Length > 0) query.Add("labels", string.Join(",", Labels));
            query.Add("sort", StringUtils.ToLower(Sort));
            query.Add("direction", StringUtils.ToLower(Direction));
            if (Since != null) query.Add("since", Since.Iso8601);
            if (Page > 0) query.Add("page", Page);
            if (PerPage > 0) query.Add("per_page", PerPage);

            // Initialize the request
            return HttpRequest
                .Get("/issues", query)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}