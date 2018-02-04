using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Models.Issues;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.PullRequests {

    /// <summary>
    /// Class representing a GitHub pull request.
    /// </summary>
    public class GitHubPullRequestItem : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the pull request.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the pull request number.
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// Gets the state of the pull request, indicating whether the pull request is open or closed.
        /// </summary>
        public GitHubIssueState State { get; }

        /// <summary>
        /// Gets whether the pull request has been locked.
        /// </summary>
        public bool IsLocked { get; }

        /// <summary>
        /// Gets the title of the pull request.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets a reference to the user who created the pull request.
        /// </summary>
        public GitHubUserItem User { get; }

        /// <summary>
        /// Gets the body of the pull request.
        /// </summary>
        public string Body { get; }

        /// <summary>
        /// Gets whether a body has been specified for the pull request.
        /// </summary>
        public bool HasBody => !String.IsNullOrWhiteSpace(Body);

        /// <summary>
        /// Gets a timestamp for when the pull request was created.
        /// </summary>
        public EssentialsDateTime CreatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the pull request was last updated.
        /// </summary>
        public EssentialsDateTime UpdatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the pull request was closed, or <code>null</code> if the pull request hasn't yet been closed.
        /// </summary>
        public EssentialsDateTime ClosedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the pull request was merged, or <code>null</code> if the pull request hasn't yet been merged.
        /// </summary>
        public EssentialsDateTime MergedAt { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the pull request.</param>
        protected GitHubPullRequestItem(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            Number = obj.GetInt32("number");
            State = obj.GetEnum<GitHubIssueState>("state");
            IsLocked = obj.GetBoolean("locked");
            Title = obj.GetString("title");
            User = obj.GetObject("user", GitHubUserItem.Parse);
            Body = obj.GetString("body");
            CreatedAt = obj.GetString("created_at", EssentialsDateTime.Parse);
            UpdatedAt = obj.GetString("updated_at", EssentialsDateTime.Parse);
            ClosedAt = obj.GetString("closed_at", EssentialsDateTime.Parse);
            MergedAt = obj.GetString("merged_at", EssentialsDateTime.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubPullRequestItem"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubPullRequestItem"/>.</returns>
        public static GitHubPullRequestItem Parse(JObject obj) {
            return obj == null ? null : new GitHubPullRequestItem(obj);
        }

        #endregion

    }

}