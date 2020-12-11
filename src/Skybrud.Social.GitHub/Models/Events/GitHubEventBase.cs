using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Models.Labels;
using Skybrud.Social.GitHub.Models.Milestones;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Events {

    /// <summary>
    /// Class representing a GitHub event.
    /// </summary>
    public abstract class GitHubEventBase : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the event.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the Global Node ID of the event.
        /// </summary>
        public string NodeId { get; }

        /// <summary>
        /// Gets the API URL for fetching the event.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the person who generated the event.
        /// </summary>
        public GitHubUserItem Actor { get; }

        /// <summary>
        /// Identifies the actual type of event that occurred.
        /// </summary>
        public GitHubEventType Event { get; }

        /// <summary>
        /// Identifies the actual type of event that occurred.
        /// </summary>
        public string EventRaw { get; }

        /// <summary>
        /// Gets the string SHA of the commit that referenced this issue.
        /// </summary>
        public string CommitId { get; }

        /// <summary>
        /// Gets the GitHub API link to a commit that referenced this issue.
        /// </summary>
        public string CommitUrl { get; }

        /// <summary>
        /// Gets the timestamp indicating when the event occurred.
        /// </summary>
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets the person who requested a review. Only provided for <see cref="GitHubEventType.ReviewRequested"/> and <see cref="GitHubEventType.ReviewRequestRemoved"/> events.
        /// </summary>
        public GitHubUserItem ReviewRequester { get; }

        /// <summary>
        /// Gets the people who were requested to review an issue. Only provided for <see cref="GitHubEventType.ReviewRequested"/> and <see cref="GitHubEventType.ReviewRequestRemoved"/> events.
        /// </summary>
        public GitHubUserItem RequestedReviewer { get; }

        /// <summary>
        /// Gets the person assigned to (or unassigned from) this issue. Only provided for <see cref="GitHubEventType.Assigned"/> and <see cref="GitHubEventType.Unassigned"/> events.
        /// </summary>
        public GitHubUserItem Assignee { get; }

        /// <summary>
        /// Gets an a array of people who are assigned to (or unassigned from) this issue. Only provided for <see cref="GitHubEventType.Assigned"/> and <see cref="GitHubEventType.Unassigned"/> events.
        /// </summary>
        public GitHubUserItem[] Assignees { get; }

        /// <summary>
        /// Gets the person who performed the assignment (or unassignment) for this issue. Only provided for <see cref="GitHubEventType.Assigned"/> and <see cref="GitHubEventType.Unassigned"/> events.
        /// </summary>
        public GitHubUserItem Assigner { get; }

        /// <summary>
        /// Gets an array of labels. Each label includes a name and color attribute. Only provided for <see cref="GitHubEventType.Labeled"/> and <see cref="GitHubEventType.Unlabeled"/> events.
        /// </summary>
        public GitHubLabelReference Label { get; }

        /// <summary>
        /// Gets the milestone object including a title attribute. Only provided for <see cref="GitHubEventType.Milestoned"/> and <see cref="GitHubEventType.Demilestoned"/> events.
        /// </summary>
        public GitHubMilestoneReference Milestone { get; }

        /// <summary>
        /// Gets the rename details including from and to attributes. Only provided for <see cref="GitHubEventType.Renamed"/> events.
        /// </summary>
        public GitHubEventRenameDetails Rename { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the event.</param>
        protected GitHubEventBase(JObject obj) : base(obj) {

            Id = obj.GetInt64("id");
            NodeId = obj.GetString("node_id");
            Url = obj.GetString("url");
            Actor = obj.GetObject("actor", GitHubUserItem.Parse);
            Event = obj.GetEnum("event", GitHubEventType.Other);
            EventRaw = obj.GetString("event");
            CommitId = obj.GetString("commit_id");
            CommitUrl = obj.GetString("commit_url");
            CreatedAt = obj.GetString("created_at", EssentialsTime.Parse);

            ReviewRequester = obj.GetObject("review_requester", GitHubUserItem.Parse);
            RequestedReviewer = obj.GetObject("requested_reviewers", GitHubUserItem.Parse);

            Assignee = obj.GetObject("assignee", GitHubUserItem.Parse);
            Assignees = obj.GetArrayItems("assignees", GitHubUserItem.Parse);
            Assigner = obj.GetObject("assigner", GitHubUserItem.Parse);

            Label = obj.GetObject("label", GitHubLabelReference.Parse);

            Milestone = obj.GetObject("milestone", GitHubMilestoneReference.Parse);

            Rename = obj.GetObject("rename", GitHubEventRenameDetails.Parse);

        }

        #endregion

    }

}