namespace Skybrud.Social.GitHub.Options.Issues {

    /// <summary>
    /// Enum class describing the state of issues to be returned by the GitHub API.
    /// </summary>
    public enum GitHubIssueState {

        /// <summary>
        /// Indicates that only open issues should be returned.
        /// </summary>
        Open,

        /// <summary>
        /// Indicates that only closed issues should be returned.
        /// </summary>
        Closed,

        /// <summary>
        /// Indicates that all issues should be returned, regardsless of their type.
        /// </summary>
        All

    }

}