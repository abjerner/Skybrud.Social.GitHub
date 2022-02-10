using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Issues {

    /// <summary>
    /// Class representing the options for getting the issues of a GitHub repository.
    /// </summary>
    public class GitHubGetRepositoryIssuesOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Mandatory: Gets or sets the username (login) of the owner of the repository.
        /// </summary>
        public string OwnerAlias { get; set; }

        /// <summary>
        /// Mandatory: Gets or sets the slug of the repository.
        /// </summary>
        public string RepositoryAlias { get; set; }

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

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubGetRepositoryIssuesOptions() { }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repositoryAlias">The slug of the repository.</param>
        public GitHubGetRepositoryIssuesOptions(string owner, string repositoryAlias) {
            OwnerAlias = owner;
            RepositoryAlias = repositoryAlias;
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public GitHubGetRepositoryIssuesOptions(GitHubRepositoryBase repository) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            OwnerAlias = repository.Owner.Login;
            RepositoryAlias = repository.Name;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {
            
            // Validate required parameters
            if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new PropertyNotSetException(nameof(OwnerAlias));
            if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new PropertyNotSetException(nameof(RepositoryAlias));

            // Initialzie the query string
            IHttpQueryString query = new HttpQueryString {
                {"state", StringUtils.ToLower(State)}
            };

            // Update the query string with additional parameters
            if (!string.IsNullOrWhiteSpace(Milestone)) query.Add("milestone", Milestone);
            if (!string.IsNullOrWhiteSpace(Assignee)) query.Add("assignee", Assignee);
            if (!string.IsNullOrWhiteSpace(Creator)) query.Add("creator", Creator);
            if (!string.IsNullOrWhiteSpace(Mentioned)) query.Add("mentioned", Mentioned);
            if (Labels != null && Labels.Length > 0) query.Add("labels", string.Join(",", Labels));
            query.Add("sort", StringUtils.ToLower(Sort));
            query.Add("direction", StringUtils.ToLower(Direction));
            if (Since != null) query.Add("since", Since.Iso8601);
            if (Page > 0) query.Add("page", Page);
            if (PerPage > 0) query.Add("per_page", PerPage);

            // Initialize a new GET request
            return HttpRequest
                .Get($"/repos/{OwnerAlias}/{RepositoryAlias}/issues", query)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}