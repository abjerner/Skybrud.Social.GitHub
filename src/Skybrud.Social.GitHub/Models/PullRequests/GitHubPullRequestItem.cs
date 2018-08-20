﻿using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Models.Issues;
using Skybrud.Social.GitHub.Models.Labels;
using Skybrud.Social.GitHub.Models.Milestones;
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

        public string node_id { get; }

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

        // TODO: Add support for the "active_lock_reason"

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
        /// Gets a timestamp for when the pull request was closed, or <c>null</c> if the pull request hasn't yet been closed.
        /// </summary>
        public EssentialsDateTime ClosedAt { get; }

        /// <summary>
        /// Gets whether the pull requsts has been closed.
        /// </summary>
        public bool IsClosed => ClosedAt != null;

        /// <summary>
        /// Gets a timestamp for when the pull request was merged, or <c>null</c> if the pull request hasn't yet been merged.
        /// </summary>
        public EssentialsDateTime MergedAt { get; }

        /// <summary>
        /// Gets whether the pull requsts has been merged.
        /// </summary>
        public bool IsMerged => MergedAt != null;

        /// <summary>
        /// Gets the SHA hash of the last commit of the pull request.
        /// </summary>
        public string MergeCommitSha { get; }

        /// <summary>
        /// Gets the user assigned to the pull requests, or <c>null</c> if no user is assigned to the pull request.
        /// 
        /// Notice that more than one user can be assigned to a pull request, so it's recommended to use the
        /// <see cref="Assignees"/> property instead, as it returns an array of the assigned users.
        /// </summary>
        public GitHubUserItem Assignee { get; }

        /// <summary>
        /// Gets an array of users assigned to the pull request.
        /// </summary>
        public GitHubUserItem[] Assignees { get; }

        /// <summary>
        /// Gets whether any users are assigned to the pull request.
        /// </summary>
        public bool HasAssignees => Assignees.Length > 0;

        // TODO: Add support for the "requested_reviewers" property

        // TODO: Add support for the "requested_teams" property

        /// <summary>
        /// Gets an array of the labels associated with the pull request.
        /// </summary>
        public GitHubLabel[] Labels { get; }

        /// <summary>
        /// Gets the milestone of the pull request, or <c>null</c> if the pull request is not part of any milestones.
        /// </summary>
        public GitHubMilestone Milestone { get; }

        // TODO: Add support for the "requested_teams" property

        // TODO: Add support for the "head" property

        // TODO: Add support for the "base" property

        // TODO: Add support for the "_links" property

        // TODO: Add support for the "author_association" property

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
            MergeCommitSha = obj.GetString("merge_commit_sha");
            Assignee = obj.GetObject("assignee", GitHubUserItem.Parse);
            Assignees = obj.GetArrayItems("assignees", GitHubUserItem.Parse);
            Labels = obj.GetArrayItems("labels", GitHubLabel.Parse);
            Milestone = obj.GetObject("milestone", GitHubMilestone.Parse);
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