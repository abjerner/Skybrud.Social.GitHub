using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Commits {

    /// <summary>
    /// Class representing a commit of a repository.
    /// </summary>
    public class GitHubCommit : GitHubObject {

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
        public GitHubCommitUrls Urls { get; }

        /// <summary>
        /// Gets information about the author of the commit.
        /// </summary>
        public GitHubUserItem? Author { get; }

        /// <summary>
        /// Gets information about the user who committed the commit.
        /// </summary>
        public GitHubUserItem? Committer { get; }

        /// <summary>
        /// Gets information about the parent commits.
        /// </summary>
        public IReadOnlyList<GitHubCommitParent> Parents { get; }

        /// <summary>
        /// Gets statistics about the commit.
        /// </summary>
        public GitHubCommitStats Stats { get; }

        /// <summary>
        /// Gets an array of files added, modified, renamed or removed in the commit.
        /// </summary>
        public IReadOnlyList<GitHubCommitFile> Files { get; }

        /// <summary>
        /// Gets whether the <see cref="Files"/> property has a value.
        /// </summary>
        public bool HasFiles => Files.Count > 0;

        #endregion

        #region Constructors

        private GitHubCommit(JObject obj) : base(obj) {
            Sha = obj.GetRequiredString("sha");
            Commit = obj.GetRequiredObject("commit", GitHubCommitDetails.Parse);
            Urls = GitHubCommitUrls.Parse(obj);
            Author = obj.GetObject("author", GitHubUserItem.Parse);
            Committer = obj.GetObject("committer", GitHubUserItem.Parse);
            Parents = obj.GetRequiredArray("parents", GitHubCommitParent.Parse);
            Stats = obj.GetRequiredObject("stats", GitHubCommitStats.Parse);
            Files = obj.GetRequiredArray("files", GitHubCommitFile.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubCommit"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubCommit"/>.</returns>
        public static GitHubCommit Parse(JObject obj) {
            return new GitHubCommit(obj);
        }

        #endregion

    }

}