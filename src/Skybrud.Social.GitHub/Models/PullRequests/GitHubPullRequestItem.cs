using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.PullRequests {

    /// <summary>
    /// Class representing a GitHub pull request.
    /// </summary>
    public class GitHubPullRequestItem : GitHubPullRequestBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the pull request.</param>
        protected GitHubPullRequestItem(JObject json) : base(json) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubPullRequestItem"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubPullRequestItem"/>.</returns>
        public static new GitHubPullRequestItem Parse(JObject json) {
            return new GitHubPullRequestItem(json);
        }

        #endregion

    }

}