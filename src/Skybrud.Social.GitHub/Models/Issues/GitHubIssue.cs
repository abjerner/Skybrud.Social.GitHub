using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Models.Issues {

    /// <summary>
    /// Class representing a GitHub issue.
    /// </summary>
    public class GitHubIssue : GitHubIssueBase {

        #region Properties

        // TODO: Add support for the "closed_by" property

        /// <summary>
        /// Gets a reference to the repository of the issue.
        /// </summary>
        public GitHubRepositoryItem Repository { get; }

        #endregion

        #region Constructors

        private GitHubIssue(JObject json) : base(json) {
            Repository = json.GetRequiredObject("repository", GitHubRepositoryItem.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubIssue"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubIssue"/>.</returns>
        public static GitHubIssue Parse(JObject obj) {
            return new GitHubIssue(obj);
        }

        #endregion

    }

}