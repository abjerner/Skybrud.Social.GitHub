namespace Skybrud.Social.GitHub.Models.Events {
    
    /// <summary>
    /// Énum class representing the type of an event.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/issues/events/#events-1</cref>
    /// </see>
    public enum GitHubEventType {

        /// <summary>
        /// The issue was added to a project board.You only see this event in responses when project boards have been
        /// enabled in the repository.
        /// </summary>
        AddedToProject,

        /// <summary>
        /// The issue was assigned to the actor.
        /// </summary>
        Assigned,

        /// <summary>
        /// The issue was closed by the actor. When the commit_id is present, it identifies the commit that closed the
        /// issue using "closes / fixes #NN" syntax.
        /// </summary>
        Closed,

        /// <summary>
        /// The issue was created by converting a note in a project board to an issue.You only see this event in
        /// responses when project boards have been enabled in the repository.
        /// </summary>
        ConvertedNoteToIssue,

        /// <summary>
        /// The issue was removed from a milestone.
        /// </summary>
        Demilestoned,

        /// <summary>
        /// The pull request's branch was deleted.
        /// </summary>
        HeadRefDeleted,

        /// <summary>
        /// The pull request's branch was restored.
        /// </summary>
        HeadRefRestored,

        /// <summary>
        /// A label was added to the issue.
        /// </summary>
        Labeled,

        /// <summary>
        /// The issue was locked by the actor.
        /// </summary>
        Locked,

        /// <summary>
        /// The actor was @mentioned in an issue body.
        /// </summary>
        Mentioned,

        /// <summary>
        /// A user with write permissions marked an issue as a duplicate of another issue or a pull request as a
        /// duplicate of another pull request.
        /// </summary>
        MarkedAsDuplicate,

        /// <summary>
        /// The issue was merged by the actor. The commit_id attribute is the SHA1 of the HEAD commit that was merged.
        /// </summary>
        Merged,

        /// <summary>
        /// The issue was added to a milestone.
        /// </summary>
        Milestoned,

        /// <summary>
        /// The issue was moved between columns in a project board.You only see this event in responses when project
        /// boards have been enabled in the repository.
        /// </summary>
        MovedColumnsInProject,

        /// <summary>
        ///  The issue was referenced from a commit message.The commit_id attribute is the commit SHA1 of where that
        /// happened.
        /// </summary>
        Referenced,

        /// <summary>
        /// The issue was removed from a project board.You only see this event in responses when project boards have
        /// been enabled in the repository.
        /// </summary>
        RemovedFromProject,

        /// <summary>
        /// The issue title was changed.
        /// </summary>
        Renamed,

        /// <summary>
        /// The issue was reopened by the actor.
        /// </summary>
        Reopened,

        /// <summary>
        /// The actor dismissed a review from the pull request.
        /// </summary>
        ReviewDismissed,

        /// <summary>
        /// The actor requested review from the subject on this pull request.
        /// </summary>
        ReviewRequested,

        /// <summary>
        /// The actor removed the review request for the subject on this pull request.
        /// </summary>
        ReviewRequestRemoved,

        /// <summary>
        /// The actor subscribed to receive notifications for an issue.
        /// </summary>
        Subscribed,

        /// <summary>
        /// The issue was transferred to another repository.
        /// </summary>
        Transferred,

        /// <summary>
        /// The actor was unassigned from the issue.
        /// </summary>
        Unassigned,

        /// <summary>
        /// A label was removed from the issue.
        /// </summary>
        Unlabeled,

        /// <summary>
        /// The issue was unlocked by the actor.
        /// </summary>
        Unlocked,

        /// <summary>
        /// An issue that a user had previously marked as a duplicate of another issue is no longer considered a
        /// duplicate, or a pull request that a user had previously marked as a duplicate of another pull request is no longer considered a duplicate.
        /// </summary>
        UnmarkedAsDuplicate,

        /// <summary>
        /// An organization owner blocked a user from the organization.
        /// </summary>
        UserBlocked

    }

}