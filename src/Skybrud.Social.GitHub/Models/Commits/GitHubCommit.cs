﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
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

        /// <summary>
        /// Gets statistics about the commit.
        /// </summary>
        public GitHubCommitStats Stats { get; }

        /// <summary>
        /// Gets an array of files added, modified, renamed or removed in the commit.
        /// </summary>
        public GitHubCommitFile[] Files { get; }

        #endregion

        #region Constructors

        private GitHubCommit(JObject obj) : base(obj) {
            Sha = obj.GetString("sha");
            Commit = obj.GetObject("commit", GitHubCommitDetails.Parse);
            Urls = GitHubCommitUrlCollection.Parse(obj);
            Author = obj.GetObject("author", GitHubUserItem.Parse);
            Committer = obj.GetObject("committer", GitHubUserItem.Parse);
            Parents = obj.GetArray("parents", GitHubCommitParent.Parse);
            Stats = obj.GetObject("stats", GitHubCommitStats.Parse);
            Files = obj.GetArray("files", GitHubCommitFile.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubCommit"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubCommit"/>.</returns>
        public static GitHubCommit Parse(JObject obj) {
            return obj == null ? null : new GitHubCommit(obj);
        }

        #endregion

    }

}