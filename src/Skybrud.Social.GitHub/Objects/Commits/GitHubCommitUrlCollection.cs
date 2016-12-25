﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Objects.Commits {

    /// <summary>
    /// Class representing a collection of URLs related to a GitHub commit.
    /// </summary>
    public class GitHubCommitUrlCollection {

        #region Properties

        /// <summary>
        /// Gets the API URL of the commit.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Gets the website URL of the commit.
        /// </summary>
        public string HtmlUrl { get; private set; }

        /// <summary>
        /// Gets the API URL for getting a list of commits of the commit.
        /// </summary>
        public string CommentsUrl { get; private set; }

        #endregion

        #region Constructor

        private GitHubCommitUrlCollection(JObject obj) {
            Url = obj.GetString("url");
            HtmlUrl = obj.GetString("html_url");
            CommentsUrl = obj.GetString("comments_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>GitHubCommitUrlCollection</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>GitHubCommitUrlCollection</code>.</returns>
        public static GitHubCommitUrlCollection Parse(JObject obj) {
            return obj == null ? null : new GitHubCommitUrlCollection(obj);
        }

        #endregion

    }

}