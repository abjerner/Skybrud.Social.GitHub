using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Models.Labels;
using Skybrud.Social.GitHub.Models.Milestones;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Issues {

    /// <summary>
    /// Class representing a GitHub issue.
    /// </summary>
    public class GitHubIssueItem : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the issue.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// Gets the issue number.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Gets the title of the issue.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets a reference to the user who created the issue.
        /// </summary>
        public GitHubUserItem User { get; private set; }

        /// <summary>
        /// Gets an array of the labels of the issue.
        /// </summary>
        public GitHubLabel[] Labels { get; private set; }

        /// <summary>
        /// Gets the state of the issue, indicating whether the issue is open or closed.
        /// </summary>
        public GitHubIssueState State { get; private set; }

        /// <summary>
        /// Gets whether the issue has been locked.
        /// </summary>
        public bool IsLocked { get; private set; }

        /// <summary>
        /// Gets a reference to the (first) user the issue is assigned to, or <code>null</code> if the issue is not
        /// assigned to any users.
        /// </summary>
        public GitHubUserItem Assignee { get; private set; }

        /// <summary>
        /// Gets an array of the users the issue is assigned to.
        /// </summary>
        public GitHubUserItem[] Assignees { get; private set; }

        /// <summary>
        /// Gets a reference to the milestone of the issue, or <code>null</code> if the issue is not part of a milestone.
        /// </summary>
        public GitHubMilestone Milestone { get; private set; }

        /// <summary>
        /// Gets whether the issue is part of a milestone.
        /// </summary>
        public bool HasMilestone {
            get { return Milestone != null; }
        }

        /// <summary>
        /// Gets the number of comment.
        /// </summary>
        public int Comments { get; private set; }

        /// <summary>
        /// Gets a timestamp for when the issue was created.
        /// </summary>
        public EssentialsDateTime CreatedAt { get; private set; }

        /// <summary>
        /// Gets a timestamp for when the issue was last updated.
        /// </summary>
        public EssentialsDateTime UpdatedAt { get; private set; }

        /// <summary>
        /// Gets a timestamp for when the issue was closed. If <see cref="State"/> is
        /// <see cref="GitHubIssueState.Open"/>, this property will return <code>null</code>.
        /// </summary>
        public EssentialsDateTime ClosedAt { get; private set; }

        /// <summary>
        /// Gets a reference to the repository of the issue.
        /// </summary>
        public GitHubRepositoryItem Repository { get; private set; }

        /// <summary>
        /// Gets the body of the issue.
        /// </summary>
        public string Body { get; private set; }

        /// <summary>
        /// Gets whether a body has been specified for the commit.
        /// </summary>
        public bool HasBody {
            get { return !String.IsNullOrWhiteSpace(Body); }
        }

        /// <summary>
        /// Gets a collection/map of URLs related to the issue.
        /// </summary>
        public GitHubIssueUrlCollection Urls { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the issue.</param>
        protected GitHubIssueItem(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            Number = obj.GetInt32("number");
            Title = obj.GetString("title");
            User = obj.GetObject("user", GitHubUserItem.Parse);
            Labels = obj.GetArrayItems("labels", GitHubLabel.Parse);
            State = obj.GetEnum<GitHubIssueState>("state");
            IsLocked = obj.GetBoolean("locked");
            Assignee = obj.GetObject("assignee", GitHubUserItem.Parse);
            Assignees = obj.GetArrayItems("assignees", GitHubUserItem.Parse);
            Milestone = obj.GetObject("milestone", GitHubMilestone.Parse);
            Comments = obj.GetInt32("comments");
            CreatedAt = obj.GetString("created_at", EssentialsDateTime.Parse);
            UpdatedAt = obj.GetString("updated_at", EssentialsDateTime.Parse);
            ClosedAt = obj.GetString("closed_at", EssentialsDateTime.Parse);
            Repository = obj.GetObject("repository", GitHubRepositoryItem.Parse);
            Body = obj.GetString("body");
            Urls = GitHubIssueUrlCollection.Parse(obj);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubIssueItem"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubIssueItem"/>.</returns>
        public static GitHubIssueItem Parse(JObject obj) {
            return obj == null ? null : new GitHubIssueItem(obj);
        }

        #endregion

    }

}