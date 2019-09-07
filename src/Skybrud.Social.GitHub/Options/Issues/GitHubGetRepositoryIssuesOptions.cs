using System;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Constants;

namespace Skybrud.Social.GitHub.Options.Issues {

    /// <summary>
    /// Class representing the options for getting the issues of a GitHub repository.
    /// </summary>
    public class GitHubGetRepositoryIssuesOptions : IHttpGetOptions {

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
        /// Gets or sets the milestone. If an integer is passed, it should refer to a milestone by its number field. If
        /// the string <c>*</c> is passed, issues with any milestone are accepted. If the string <c>none</c> is passed,
        /// issues without milestones are returned.
        /// </summary>
        public string Milestone { get; set; }

        /// <summary>
        /// Gets or sets the state of the pull requests that should be returned. Default is <see cref="GitHubIssueState.Open"/>.
        /// </summary>
        public GitHubIssueState State { get; set; }

        /// <summary>
        /// Gets or sets the assignee. Can be the name of a user. Pass in <c>none</c> for issues with no assigned user, and <c>*</c> for issues assigned to any user.
        /// </summary>
        public string Assignee { get; set; }

        /// <summary>
        /// Gets or sets the user that created the issue.
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// Gets or sets the user that's mentioned in the issue.
        /// </summary>
        public string Mentioned { get; set; }

        /// <summary>
        /// Gets or sets an array of label names the returned issues should match.
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
        /// Only issues updated at or after this time are returned. Default is <c>null</c>.
        /// </summary>
        public EssentialsDateTime Since { get; set; }

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

        /// <summary>
        /// Generates an instance of <see cref="IHttpQueryString"/> representing the options.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {

            IHttpQueryString query = new HttpQueryString {
                {"state", StringUtils.ToLower(State)}
            };

            if (!String.IsNullOrWhiteSpace(Milestone)) query.Add("milestone", Milestone);
            if (!String.IsNullOrWhiteSpace(Assignee)) query.Add("assignee", Assignee);
            if (!String.IsNullOrWhiteSpace(Creator)) query.Add("creator", Creator);
            if (!String.IsNullOrWhiteSpace(Mentioned)) query.Add("mentioned", Mentioned);
            if (Labels != null && Labels.Length > 0) query.Add("labels", String.Join(",", Labels));

            query.Add("sort", StringUtils.ToLower(Sort));
            query.Add("direction", StringUtils.ToLower(Direction));
            
            if (Since != null) query.Add("since", Since.ToString(GitHubConstants.DateTimeFormat));

            if (Page > 0) query.Add("page", Page);
            if (PerPage > 0) query.Add("per_page", PerPage);

            return query;

        }

        #endregion

    }

}