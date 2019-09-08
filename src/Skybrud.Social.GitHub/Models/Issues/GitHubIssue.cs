using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Issues {

    /// <summary>
    /// Class representing a GitHub issue.
    /// </summary>
    public class GitHubIssue : GitHubIssueBase {

        #region Properties

        // TODO: Add support for the "closed_by" property

        #endregion

        #region Constructors

        private GitHubIssue(JObject obj) : base(obj) {
            // TODO: Add support for the "closed_by" property
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubIssue"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubIssue"/>.</returns>
        public static GitHubIssue Parse(JObject obj) {
            return obj == null ? null : new GitHubIssue(obj);
        }

        #endregion

    }

}