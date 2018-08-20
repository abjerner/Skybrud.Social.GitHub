using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Models.Issues;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Milestones {

    /// <summary>
    /// Class representing a GitHub milestone.
    /// </summary>
    public class GitHubMilestone : GitHubObject {

        #region Properties

        // TODO: Add support for the "url" property

        // TODO: Add support for the "html_url" property

        // TODO: Add support for the "labels_url" property

        /// <summary>
        /// Gets the ID of the milestone.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the number of the milestone.
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// Gets the title of the milestone.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the description of the milestone.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets whether a description has been specified for the milestone.
        /// </summary>
        public bool HasDescription => String.IsNullOrWhiteSpace(Description);

        /// <summary>
        /// Gets a reference to the user who created the milestone.
        /// </summary>
        public GitHubUser Creator { get; }

        /// <summary>
        /// Gets the amount of open issues in the milestone.
        /// </summary>
        public int OpenIssues { get; }

        /// <summary>
        /// Gets the amount of closed issues in the milestone.
        /// </summary>
        public int ClosedIssues { get; }

        /// <summary>
        /// Gets the state of the milestone, indicating whether the milestone is open or closed.
        /// </summary>
        public GitHubIssueState State { get; }

        /// <summary>
        /// Gets a timestamp for when the issue was created.
        /// </summary>
        public EssentialsDateTime CreatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the issue was last updated.
        /// </summary>
        public EssentialsDateTime UpdatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the milestone is due, or <c>null</c> if the milestone doesn't have a due date.
        /// </summary>
        public EssentialsDateTime DueOn { get; }

        /// <summary>
        /// Gets whether a due date has been specified for the milestone.
        /// </summary>
        public bool HasDueOn => DueOn != null;

        /// <summary>
        /// Gets a timestamp for when the milestone was closed. If <see cref="State"/> is
        /// <see cref="GitHubIssueState.Open"/>, this property will return <c>null</c>.
        /// </summary>
        public EssentialsDateTime ClosedAt { get; }

        #endregion

        #region Constructors

        private GitHubMilestone(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            Number = obj.GetInt32("number");
            Title = obj.GetString("title");
            Description = obj.GetString("description");
            Creator = obj.GetObject("creator", GitHubUser.Parse);
            OpenIssues = obj.GetInt32("open_issues");
            ClosedIssues = obj.GetInt32("closed_issues");
            State = obj.GetEnum<GitHubIssueState>("state");
            CreatedAt = obj.GetString("created_at", EssentialsDateTime.Parse);
            UpdatedAt = obj.GetString("updated_at", EssentialsDateTime.Parse);
            DueOn = obj.GetString("due_on", EssentialsDateTime.Parse);
            ClosedAt = obj.GetString("closed_at", EssentialsDateTime.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubMilestone"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubMilestone"/>.</returns>
        public static GitHubMilestone Parse(JObject obj) {
            return obj == null ? null : new GitHubMilestone(obj);
        }

        #endregion

    }

}