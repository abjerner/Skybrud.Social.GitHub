using System;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Constants;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.GitHub.Options.Issues {
    
    /// <summary>
    /// Class representing the options for getting a list of issues.
    /// </summary>
    public class GitHubGetIssuesOptions : IHttpGetOptions {

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
        /// The direction of the sort.. Default is <see cref="GitHubSortDirection.Descending"/>.
        /// </summary>
        public GitHubSortDirection Direction { get; set; }

        /// <summary>
        /// Only issues updated at or after this time are returned. Default is <code>null</code>.
        /// </summary>
        public EssentialsDateTime Since { get; set; }

        public int Page { get; set; }

        public int PerPage { get; set; }

        #endregion

        #region Member methods

        /// <summary>
        /// Generates an instance of <see cref="IHttpQueryString"/> representing the options.
        /// </summary>
        /// <returns>Returns an instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {

            SocialHttpQueryString query = new SocialHttpQueryString();

            query.Add("filter", StringUtils.ToLower(Filter));
            query.Add("state", StringUtils.ToLower(State));

            if (Labels != null && Labels.Length > 0) {
                query.Add("labels", String.Join(",", Labels));
            }

            query.Add("sort", StringUtils.ToLower(Sort));
            query.Add("direction", StringUtils.ToLower(Direction));
            
            if (Since != null) {
                query.Add("since", Since.ToString(GitHubConstants.DateTimeFormat));
            }

            if (Page > 0) {
                query.Add("page", Page);
            }

            if (PerPage > 0) {
                query.Add("per_page", PerPage);
            }

            return query;

        }

        #endregion

    }

}