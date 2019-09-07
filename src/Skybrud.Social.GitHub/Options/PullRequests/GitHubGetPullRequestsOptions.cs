using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.GitHub.Options.Issues;
using Skybrud.Social.GitHub.Options.Repositories;

namespace Skybrud.Social.GitHub.Options.PullRequests {

    /// <summary>
    /// Class representing the options for getting a list of pull requests of a given repository.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/pulls/#list-pull-requests</cref>
    /// </see>
    public class GitHubGetPullRequestsOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Mandatory: Gets or sets the username (login) of the owner of the repository.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Mandatory: Gets or sets the slug of the repository.
        /// </summary>
        public string Repository { get; set; }

        /// <summary>
        /// Gets or sets the state of the pull requests that should be returned. Default is <see cref="GitHubIssueState.Open"/>.
        /// </summary>
        public GitHubIssueState State { get; set; }

        /// <summary>
        /// What to sort results by. Default is <see cref="GitHubPullRequestSortField.Created"/>.
        /// </summary>
        public GitHubPullRequestSortField Sort { get; set; }

        /// <summary>
        /// The direction of the sort. Default is <see cref="GitHubSortDirection.Descending"/>.
        /// </summary>
        public GitHubSortDirection Direction { get; set; }

        /// <summary>
        /// Gets or sets the page to be returned. Default is <code>0</code>, indicating the first page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of pull requests to be returned by each page.
        /// </summary>
        public int PerPage { get; set; }

        #endregion

        #region Member methods

        /// <summary>
        /// Generates an instance of <see cref="IHttpQueryString"/> representing the options.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {

            IHttpQueryString query = new HttpQueryString {
                {"state", State.ToKebabCase()}
            };

            query.Add("sort", Sort.ToKebabCase());
            query.Add("direction", Direction == GitHubSortDirection.Descending ? "desc" : "asc");

            if (Page > 0) query.Add("page", Page);
            if (PerPage > 0) query.Add("per_page", PerPage);

            return query;

        }

        #endregion

    }

}