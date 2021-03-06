﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Commits {

    /// <summary>
    /// Class representing a collection of URLs related to a GitHub commit.
    /// </summary>
    public class GitHubCommitUrls {

        #region Properties

        /// <summary>
        /// Gets the API URL of the commit.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the website URL of the commit.
        /// </summary>
        public string HtmlUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of commits of the commit.
        /// </summary>
        public string CommentsUrl { get; }

        #endregion

        #region Constructors

        private GitHubCommitUrls(JObject obj) {
            Url = obj.GetString("url");
            HtmlUrl = obj.GetString("html_url");
            CommentsUrl = obj.GetString("comments_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubCommitUrls"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubCommitUrls"/>.</returns>
        public static GitHubCommitUrls Parse(JObject obj) {
            return obj == null ? null : new GitHubCommitUrls(obj);
        }

        #endregion

    }

}