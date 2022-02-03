using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Issues {

    /// <summary>
    /// Class representing a GitHub issue.
    /// </summary>
    public class GitHubIssueItem : GitHubIssueBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the issue.</param>
        protected GitHubIssueItem(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubIssueItem"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubIssueItem"/>.</returns>
        public static GitHubIssueItem Parse(JObject obj) {
            return obj == null ? null : new GitHubIssueItem(obj);
        }

        #endregion

    }

}