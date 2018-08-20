using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.PullRequests.Reviews {

    public class GitHubReviewItem : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the review.
        /// </summary>
        public long Id { get; }

        public string NodeId { get; }

        public GitHubUserItem User { get; }

        public string Body { get; }

        public GitHubReviewState State { get; }

        public string HtmlUrl { get; }

        public string PullRequestUrl { get; }

        // TODO: Add support for the "author_association" property

        // TODO: Add support for the "_links" property

        /// <summary>
        /// Gets a timestamp for when the review was submitted.
        /// </summary>
        public EssentialsDateTime SubmittedAt { get; }

        // TODO: Add support for the "commit_id" property

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the pull request.</param>
        protected GitHubReviewItem(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            NodeId = obj.GetString("node_id");
            User = obj.GetObject("user", GitHubUserItem.Parse);
            Body = obj.GetString("body");
            State = obj.GetEnum<GitHubReviewState>("state");
            HtmlUrl = obj.GetString("html_url");
            PullRequestUrl = obj.GetString("pull_request_url");
            // TODO: Add support for the "author_association" property
            // TODO: Add support for the "_links" property
            SubmittedAt = obj.GetString("submitted_at", EssentialsDateTime.Parse);
            // TODO: Add support for the "commit_id" property
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubReviewItem"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubReviewItem"/>.</returns>
        public static GitHubReviewItem Parse(JObject obj) {
            return obj == null ? null : new GitHubReviewItem(obj);
        }

        #endregion

    }

}