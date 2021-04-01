using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Issues.Comments {

    /// <summary>
    /// Class representing a comment of a GitHub issue.
    /// </summary>
    public class GitHubComment : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the comment.
        /// </summary>
        public long Id { get; }

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
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the comment was last updated.
        /// </summary>
        public EssentialsTime UpdatedAt { get; }

        /// <summary>
        /// Gets a collection/map of URLs related to the comment.
        /// </summary>
        public GitHubCommentUrlCollection Urls { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the issue.</param>
        protected GitHubComment(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            NodeId = obj.GetString("node_id");
            Url = obj.GetString("url");
            HtmlUrl = obj.GetString("html_url");
            Body = obj.GetString("body");
            User = obj.GetObject("user", GitHubUserItem.Parse);
            CreatedAt = obj.GetEssentialsTime("created_at");
            UpdatedAt = obj.GetEssentialsTime("updated_at");
            Urls = GitHubCommentUrlCollection.Parse(obj);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubComment"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubComment"/>.</returns>
        public static GitHubComment Parse(JObject obj) {
            return obj == null ? null : new GitHubComment(obj);
        }

        #endregion

    }

}