namespace Skybrud.Social.GitHub.Options.Issues {

    /// <summary>
    /// Enum class indicating which field results should be sorted by.
    /// </summary>
    public enum GitHubIssueSortField {

        /// <summary>
        /// Indicates that issues should be sorted by their creation date.
        /// </summary>
        Created,

        /// <summary>
        /// Indicates that issues should be sorted by when they were last updated.
        /// </summary>
        Updated,

        /// <summary>
        /// Indicates that issues should be sorted by the number of comments.
        /// </summary>
        Comments

    }

}