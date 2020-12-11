namespace Skybrud.Social.GitHub.Models.Events {

    /// <summary>
    /// Enum class representing the type of an event.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types</cref>
    /// </see>
    public enum GitHubEventType {
        
        /// <summary>
        /// The issue was added to a project board. You only see this event in responses when project boards have been
        /// enabled in the repository.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#added_to_project</cref>
        /// </see>
        AddedToProject,

        /// <summary>
        /// The issue was assigned to the actor.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#assigned</cref>
        /// </see>
        Assigned,

        /// <summary>
        /// GitHub unsuccessfully attempted to automatically change the base branch of the pull request.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#automatic_base_change_failed</cref>
        /// </see>
        AutomaticBaseChangeFailed,

        /// <summary>
        /// GitHub successfully attempted to automatically change the base branch of the pull request.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#automatic_base_change_succeeded</cref>
        /// </see>
        AutomaticBaseChangeSucceeded,

        /// <summary>
        /// The base reference branch of the pull request changed.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#base_ref_changed</cref>
        /// </see>
        BaseRefChanged,

        /// <summary>
        /// The issue was closed by the actor. When the commit_id is present, it identifies the commit that closed the
        /// issue using "closes / fixes #NN" syntax.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#closed</cref>
        /// </see>
        Closed,

        /// <summary>
        /// A comment was added to the issue or pull request.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#commented</cref>
        /// </see>
        Commented,

        /// <summary>
        /// A commit was added to the pull request's <c>HEAD</c> branch.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#committed</cref>
        /// </see>
        Committed,

        /// <summary>
        /// The issue or pull request was linked to another issue or pull request.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#connected</cref>
        /// </see>
        Connected,

        /// <summary>
        /// The pull request was converted to draft mode.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#convert_to_draft</cref>
        /// </see>
        ConvertToDraft,

        /// <summary>
        /// The issue was created by converting a note in a project board to an issue.You only see this event in
        /// responses when project boards have been enabled in the repository.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#converted_note_to_issue</cref>
        /// </see>
        ConvertedNoteToIssue,

        /// <summary>
        /// The issue or pull request was referenced from another issue or pull request.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#cross-referenced</cref>
        /// </see>
        CrossReferenced,

        /// <summary>
        /// The issue was removed from a milestone.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#demilestoned</cref>
        /// </see>
        Demilestoned,

        /// <summary>
        /// The pull request was deployed.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#deployed</cref>
        /// </see>
        Deployed,

        /// <summary>
        /// The pull request deployment environment was changed.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#deployment_environment_changed</cref>
        /// </see>
        DeploymentEnvironmentChanged,

        /// <summary>
        /// The issue or pull request was unlinked from another issue or pull request.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#disconnected</cref>
        /// </see>
        Disconnected,

        /// <summary>
        /// The pull request's <c>HEAD</c> branch was deleted.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#head_ref_deleted</cref>
        /// </see>
        HeadRefDeleted,

        /// <summary>
        /// The pull request's <c>HEAD</c> branch was restored.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#head_ref_restored</cref>
        /// </see>
        HeadRefRestored,

        /// <summary>
        /// A label was added to the issue or pull request.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#labeled</cref>
        /// </see>
        Labeled,

        /// <summary>
        /// The issue or pull request was locked.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#locked</cref>
        /// </see>
        Locked,

        /// <summary>
        /// The actor was <c>@mentioned</c> in an issue or pull request body.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#mentioned</cref>
        /// </see>
        Mentioned,

        /// <summary>
        /// A user with write permissions marked an issue as a duplicate of another issue, or a pull request as a
        /// duplicate of another pull request.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#marked_as_duplicate</cref>
        /// </see>
        MarkedAsDuplicate,

        /// <summary>
        /// The pull request was merged. The <c>commit_id</c> attribute is the SHA1 of the <c>HEAD</c> commit that was
        /// merged. The <c>commit_repository</c> is always the same as the main repository.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#merged</cref>
        /// </see>
        Merged,

        /// <summary>
        /// The issue or pull request was added to a milestone.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#milestoned</cref>
        /// </see>
        Milestoned,

        /// <summary>
        /// The issue or pull request was moved between columns in a project board. You only see this event in
        /// responses when project boards have been enabled in the repository.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#moved_columns_in_project</cref>
        /// </see>
        MovedColumnsInProject,

        /// <summary>
        /// The issue was pinned.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#pinned</cref>
        /// </see>
        Pinned,

        /// <summary>
        /// A pull request was created that is not in draft mode.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#ready_for_review</cref>
        /// </see>
        ReadyForReview,

        /// <summary>
        /// The issue was referenced from a commit message. The <c>commit_id</c> attribute is the commit SHA1 of where
        /// that happened and the <c>commit_repository</c> is where that commit was pushed.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#referenced</cref>
        /// </see>
        Referenced,

        /// <summary>
        /// The issue or pull request was removed from a project board. You only see this event in responses when
        /// project boards have been enabled in the repository.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#removed_from_project</cref>
        /// </see>
        RemovedFromProject,

        /// <summary>
        /// The issue or pull request title was changed.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#renamed</cref>
        /// </see>
        Renamed,

        /// <summary>
        /// The issue or pull request was reopened.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#reopened</cref>
        /// </see>
        Reopened,

        /// <summary>
        /// The pull request review was dismissed.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#review_dismissed</cref>
        /// </see>
        ReviewDismissed,

        /// <summary>
        /// A pull request review was requested.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#review_requested</cref>
        /// </see>
        ReviewRequested,

        /// <summary>
        /// A pull request review request was removed.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#review_request_removed</cref>
        /// </see>
        ReviewRequestRemoved,

        /// <summary>
        /// The pull request was reviewed.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#reviewed</cref>
        /// </see>
        Reviewed,

        /// <summary>
        /// Someone subscribed to receive notifications for an issue or pull request.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#subscribed</cref>
        /// </see>
        Subscribed,

        /// <summary>
        /// The issue was transferred to another repository.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#transferred</cref>
        /// </see>
        Transferred,

        /// <summary>
        /// A user was unassigned from the issue.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#unassigned</cref>
        /// </see>
        Unassigned,

        /// <summary>
        /// A label was removed from the issue.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#unlabeled</cref>
        /// </see>
        Unlabeled,

        /// <summary>
        /// The issue was unlocked.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#unlocked</cref>
        /// </see>
        Unlocked,

        /// <summary>
        /// An issue that a user had previously marked as a duplicate of another issue is no longer considered a duplicate, or a pull request that a user had previously marked as a duplicate of another pull request is no longer considered a duplicate.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#unmarked_as_duplicate</cref>
        /// </see>
        UnmarkedAsDuplicate,

        /// <summary>
        /// The issue was unpinned.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#unpinned</cref>
        /// </see>
        Unpinned,

        /// <summary>
        /// Someone unsubscribed from receiving notifications for an issue or pull request.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#unsubscribed</cref>
        /// </see>
        Unsubscribed,

        /// <summary>
        /// An organization owner blocked a user from the organization.
        /// </summary>
        /// <see>
        ///     <cref>https://docs.github.com/en/free-pro-team@latest/developers/webhooks-and-events/issue-event-types#user_blocked</cref>
        /// </see>
        UserBlocked,

        /// <summary>
        /// Indicates an event type unknown by this package.
        /// </summary>
        Other

    }

}