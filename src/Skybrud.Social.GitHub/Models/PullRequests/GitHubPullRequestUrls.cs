using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.PullRequests {

    /// <summary>
    /// Class representing a collection of URLs related to a GitHub pull request.
    /// </summary>
    public class GitHubPullRequestUrls {

        #region Properties

        /// <summary>
        /// Gets the API URL of the user.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the website URL of the issue.
        /// </summary>
        public string HtmlUrl { get; }

        /// <summary>
        /// Gets the diff URL of the pull request.
        /// </summary>
        public string DiffUrl { get; }

        /// <summary>
        /// Gets the patch URL of the pull request.
        /// </summary>
        public string PatchUrl { get; }

        /// <summary>
        /// Gets the API URL of the underlying issue.
        /// </summary>
        public string IssueUrl { get; }

        /// <summary>
        /// Gets for API URL for getting the commits made to this pull request.
        /// </summary>
        public string CommitsUrl { get; }

        /// <summary>
        /// Gets the review comments URL of the pull request.
        /// </summary>
        public string ReviewCommentsUrl { get; }

        /// <summary>
        /// Gets the review comment URL of the pull request.
        /// </summary>
        public string ReviewCommentUrl { get; }

        /// <summary>
        /// Gets the comments URL of the pull request.
        /// </summary>
        public string CommentsUrl { get; }

        /// <summary>
        /// Gets the statuses URL of the pull request.
        /// </summary>
        public string StatusesUrl { get; }

        #endregion

        #region Constructors

        private GitHubPullRequestUrls(JObject obj) {
            Url = obj.GetString("url");
            HtmlUrl = obj.GetString("html_url");
            DiffUrl = obj.GetString("diff_url");
            PatchUrl = obj.GetString("patch_url");
            IssueUrl = obj.GetString("issue_url");
            CommitsUrl = obj.GetString("commits_url");
            ReviewCommentsUrl = obj.GetString("review_comments_url");
            ReviewCommentUrl = obj.GetString("review_comment_url");
            CommentsUrl = obj.GetString("comments_url");
            StatusesUrl = obj.GetString("statuses_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubPullRequestUrls"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubPullRequestUrls"/>.</returns>
        public static GitHubPullRequestUrls Parse(JObject obj) {
            return obj == null ? null : new GitHubPullRequestUrls(obj);
        }

        #endregion

    }

}