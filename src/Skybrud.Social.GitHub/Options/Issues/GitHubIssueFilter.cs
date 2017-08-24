namespace Skybrud.Social.GitHub.Options.Issues {

    /// <summary>
    /// Enum class indicating which sorts of issues to return.
    /// </summary>
    public enum GitHubIssueFilter {

        /// <summary>
        /// Issues assigned to the authenticated user.
        /// </summary>
        Assigned,

        /// <summary>
        /// Issues created by the authenticated user.
        /// </summary>
        Created,

        /// <summary>
        /// Issues in which the authenticated user has been mentioned.
        /// </summary>
        Mentioned,
        
        /// <summary>
        /// Issues to which the authenticated user has subscribed.
        /// </summary>
        Subscribed,

        /// <summary>
        /// All issues the authenticated user can see, regardless of participation or creation.
        /// </summary>
        All

    }

}