using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Commits {

    /// <summary>
    /// Class representing a summary about a given commit.
    /// </summary>
    public class GitHubCommitSummary : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the SHA hash of the commit.
        /// </summary>
        public string Sha { get; }

        /// <summary>
        /// Gets details about the commit.
        /// </summary>
        public GitHubCommitDetails Commit { get; }

        /// <summary>
        /// Gets a reference to a collection of URLs related to the commit.
        /// </summary>
        public GitHubCommitUrlCollection Urls { get; }

        /// <summary>
        /// Gets information about the author of the commit.
        /// </summary>
        public GitHubUserItem Author { get; }

        /// <summary>
        /// Gets information about the user who committed the commit.
        /// </summary>
        public GitHubUserItem Committer { get; }

        /// <summary>
        /// Gets information about the parent commits.
        /// </summary>
        public GitHubCommitParent[] Parents { get; }

        #endregion

        #region Constructors

        private GitHubCommitSummary(JObject obj) : base(obj) {
            Sha = obj.GetString("sha");
            Commit = obj.GetObject("commit", GitHubCommitDetails.Parse);
            Urls = GitHubCommitUrlCollection.Parse(obj);
            Author = obj.GetObject("author", GitHubUserItem.Parse);
            Committer = obj.GetObject("committer", GitHubUserItem.Parse);
            Parents = obj.GetArray("parents", GitHubCommitParent.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubCommitSummary"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubCommitSummary"/>.</returns>
        public static GitHubCommitSummary Parse(JObject obj) {
            return obj == null ? null : new GitHubCommitSummary(obj);
        }

        #endregion

    }

}
