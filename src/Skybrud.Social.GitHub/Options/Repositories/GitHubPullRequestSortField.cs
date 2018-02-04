namespace Skybrud.Social.GitHub.Options.Repositories {

    /// <summary>
    /// Enum class indicating which field results should be sorted by.
    /// </summary>
    public enum GitHubPullRequestSortField {

        /// <summary>
        /// Indicates that pull requests should be sorted by their creation date.
        /// </summary>
        Created,

        /// <summary>
        /// Indicates that pull requests should be sorted by when they were last updated.
        /// </summary>
        Updated,

        /// <summary>
        /// Indicates that pull requests should be sorted by their popularity (number of comments).
        /// </summary>
        Popularity,

        /// <summary>
        /// Indicates that pull requests should be sorted by their age.
        /// </summary>
        LongRunning

    }

}