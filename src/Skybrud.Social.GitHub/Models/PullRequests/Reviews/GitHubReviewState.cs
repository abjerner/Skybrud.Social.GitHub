namespace Skybrud.Social.GitHub.Models.PullRequests.Reviews {

    /// <summary>
    /// Enum class representing the state of a review.
    /// </summary>
    public enum GitHubReviewState {

        /// <summary>
        /// Indicates that the reviewer made a comment to the PR.
        /// </summary>
        Commented,

        /// <summary>
        /// Indicates that the reviewer requested some changes to the PR.
        /// </summary>
        ChangesRequested,

        /// <summary>
        /// Indicates that the reviewer approved the PR.
        /// </summary>
        Approved,

        /// <summary>
        /// Indicates that the reviewer dismissed the PR.
        /// </summary>
        Dismissed

    }

}