namespace Skybrud.Social.GitHub.Models.Commits {

    /// <summary>
    /// Enum class indicating status of a file in a commit.
    /// </summary>
    public enum GitHubCommitFileStatus {

        /// <summary>
        /// Indicates that the file was added to the repository.
        /// </summary>
        Added,

        /// <summary>
        /// Indicates that the file was modified.
        /// </summary>
        Modified,

        /// <summary>
        /// Indicates that the file was renamed.
        /// </summary>
        Renamed,

        /// <summary>
        /// Indicates that the file was removed from the repository.
        /// </summary>
        Removed

    }

}