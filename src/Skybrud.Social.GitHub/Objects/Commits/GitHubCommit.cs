using Newtonsoft.Json.Linq;
using Skybrud.Social.GitHub.Objects.Users;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Objects.Commits {
    
    /// <summary>
    /// Class representing a commit of a repository.
    /// </summary>
    public class GitHubCommit : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the SHA hash of the commit.
        /// </summary>
        public string Sha { get; private set; }

        /// <summary>
        /// Gets details about the commit.
        /// </summary>
        public GitHubCommitDetails Commit { get; private set; }

        /// <summary>
        /// Gets a reference to a collection of URLs related to the commit.
        /// </summary>
        public GitHubCommitUrlCollection Urls { get; private set; }

        /// <summary>
        /// Gets information about the author of the commit.
        /// </summary>
        public GitHubUserSummary Author { get; private set; }

        /// <summary>
        /// Gets information about the user who committed the commit.
        /// </summary>
        public GitHubUserSummary Committer { get; private set; }

        /// <summary>
        /// Gets information about the parent commits.
        /// </summary>
        public GitHubCommitParent[] Parents { get; private set; }

        /// <summary>
        /// Gets statistics about the commit.
        /// </summary>
        public GitHubCommitStats Stats { get; private set; }

        /// <summary>
        /// Gets an array of files added, modified, renamed or removed in the commit.
        /// </summary>
        public GitHubCommitFile[] Files { get; private set; }

        #endregion

        #region Constructor

        private GitHubCommit(JObject obj) : base(obj) {
            Sha = obj.GetString("sha");
            Commit = obj.GetObject("commit", GitHubCommitDetails.Parse);
            Urls = GitHubCommitUrlCollection.Parse(obj);
            Author = obj.GetObject("author", GitHubUserSummary.Parse);
            Committer = obj.GetObject("committer", GitHubUserSummary.Parse);
            Parents = obj.GetArray("parents", GitHubCommitParent.Parse);
            Stats = obj.GetObject("stats", GitHubCommitStats.Parse);
            Files = obj.GetArray("files", GitHubCommitFile.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>GitHubCommit</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>GitHubCommit</code>.</returns>
        public static GitHubCommit Parse(JObject obj) {
            return obj == null ? null : new GitHubCommit(obj);
        }

        #endregion

    }

}
