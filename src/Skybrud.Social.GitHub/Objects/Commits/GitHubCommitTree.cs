﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Objects.Commits {
    
    /// <summary>
    /// Class representing the tree of a given commit.
    /// </summary>
    public class GitHubCommitTree : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the SHA hash of the tree.
        /// </summary>
        public string Sha { get; private set; }
        
        /// <summary>
        /// Gets the API URL of the tree.
        /// </summary>
        public string Url { get; private set; }
        
        #endregion

        #region Constructor

        private GitHubCommitTree(JObject obj) : base(obj) {
            Sha = obj.GetString("sha");
            Url = obj.GetString("url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>GitHubCommitTree</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>GitHubCommitTree</code>.</returns>
        public static GitHubCommitTree Parse(JObject obj) {
            return obj == null ? null : new GitHubCommitTree(obj);
        }

        #endregion

    }

}