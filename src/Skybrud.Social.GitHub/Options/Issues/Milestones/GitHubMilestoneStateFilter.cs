namespace Skybrud.Social.GitHub.Options.Issues.Milestones {

    /// <summary>
    /// Enum class representing a state filter for milestones.
    /// </summary>
    public enum GitHubMilestoneStateFilter {

        /// <summary>
        /// Indicates that only open milestones should be returned.
        /// </summary>
        Open,

        /// <summary>
        /// Indicates that only closed milestones should be returned.
        /// </summary>
        Closed,

        /// <summary>
        /// Indicates that all milestones should be returned regardless of their state.
        /// </summary>
        All

    }

}