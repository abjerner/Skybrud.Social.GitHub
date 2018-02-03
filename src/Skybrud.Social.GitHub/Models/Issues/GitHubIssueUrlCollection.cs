using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Issues {

    /// <summary>
    /// Class representing a collection of URLs related to a GitHub issue.
    /// </summary>
    public class GitHubIssueUrlCollection {

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
        /// Gets the API URL for getting the repository of the issue.
        /// </summary>
        public string RepositoryUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of labels of the issue.
        /// </summary>
        public string LabelsUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of comments of the issue.
        /// </summary>
        public string CommentsUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of events of the issue.
        /// </summary>
        public string EventsUrl { get; }

        #endregion

        #region Constructors

        private GitHubIssueUrlCollection(JObject obj) {
            Url = obj.GetString("url");
            HtmlUrl = obj.GetString("html_url");
            RepositoryUrl = obj.GetString("repository_url");
            LabelsUrl = obj.GetString("labels_url");
            CommentsUrl = obj.GetString("comments_url");
            EventsUrl = obj.GetString("events_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubIssueUrlCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubIssueUrlCollection"/>.</returns>
        public static GitHubIssueUrlCollection Parse(JObject obj) {
            return obj == null ? null : new GitHubIssueUrlCollection(obj);
        }

        #endregion

    }

}