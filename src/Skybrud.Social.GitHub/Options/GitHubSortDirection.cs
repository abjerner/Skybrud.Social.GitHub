namespace Skybrud.Social.GitHub.Options {

    /// <summary>
    /// Enum class indicating in which order results should be sorted.
    /// </summary>
    public enum GitHubSortDirection {

        /// <summary>
        /// Indicates that a sort direction isn't specified, using API default instead.
        /// </summary>
        Unspecified,

        /// <summary>
        /// Indicates that results should be sorted in ascending order.
        /// </summary>
        Ascending,

        /// <summary>
        /// Indicates that results should be sorted in descending order.
        /// </summary>
        Descending

    }

}