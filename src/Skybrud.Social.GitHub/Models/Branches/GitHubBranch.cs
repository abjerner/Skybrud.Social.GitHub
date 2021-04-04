using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Branches {

    /// <summary>
    /// Class representing a GitHub branch.
    /// </summary>
    public class GitHubBranch : GitHubBranchBase {

        #region Constructors

        private GitHubBranch(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubBranch"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubBranch"/>.</returns>
        public static new GitHubBranch Parse(JObject obj) {
            return obj == null ? null : new GitHubBranch(obj);
        }

        #endregion

    }

}