namespace Skybrud.Social.GitHub.Options.Repositories {
    
    /// <summary>
    /// Enum class indicating the sort order when returning a list of repositories.
    /// </summary>
    public enum GitHubRepositorySortField {

        /// <summary>
        /// Indicates that a sort order hasn't been specified. GitHub's default sorting for repositories will be used instead.
        /// </summary>
        Unspecified,

        /// <summary>
        /// Indicates that the returned repositories will be sorted by when they were created.
        /// </summary>
        Created,

        /// <summary>
        /// Indicates that the returned repositories will be sorted by when they were last updated.
        /// </summary>
        Updated,

        /// <summary>
        /// Indicates that the returned repositories will be sorted by when they were last pushed to.
        /// </summary>
        Pushed,

        /// <summary>
        /// Indicates that the returned repositories will be sorted by their full name.
        /// </summary>
        FullName

    }

}