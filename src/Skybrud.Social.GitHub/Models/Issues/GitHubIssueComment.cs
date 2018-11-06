using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Issues {

    /// <summary>
    /// Class representing a comment of an issue.
    /// </summary>
    public class GitHubIssueComment : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the comment.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the node ID of the comment.
        /// </summary>
        public string NodeId { get; }

        /// <summary>
        /// Gets the API URL of the comment.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the web URL of the comment.
        /// </summary>
        public string HtmlUrl { get; }

        /// <summary>
        /// Gets the Markdown-based body of the comment.
        /// </summary>
        public string Body { get; }

        /// <summary>
        /// Gets information about the user who created the comment.
        /// </summary>
        public GitHubUserItem User { get; }

        /// <summary>
        /// Gets a timestamp for when the comment was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the comment was last updated.
        /// </summary>
        public DateTimeOffset UpdatedAt { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The an instance of <see cref="JObject"/> representing the comment.</param>
        protected GitHubIssueComment(JObject obj) : base(obj) {
            Id = obj.GetInt32("id");
            NodeId = obj.GetString("node_id");
            Url = obj.GetString("url");
            HtmlUrl = obj.GetString("html_url");
            Body = obj.GetString("body");
            User = obj.GetObject("user", GitHubUserItem.Parse);
            CreatedAt = obj.GetString("created_at", DateTimeOffset.Parse);
            UpdatedAt = obj.GetString("updated_at", DateTimeOffset.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubIssueComment"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubIssueComment"/>.</returns>
        public static GitHubIssueComment Parse(JObject obj) {
            return obj == null ? null : new GitHubIssueComment(obj);
        }

        #endregion

    }

}