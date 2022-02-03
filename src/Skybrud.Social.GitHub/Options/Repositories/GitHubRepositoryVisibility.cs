namespace Skybrud.Social.GitHub.Options.Repositories {

    /// <summary>
    /// Enum class indicating the visibility the returned repositories should match.
    /// </summary>
    public enum GitHubRepositoryVisibility {

        /// <summary>
        /// Indicates that all repositories should be returned.
        /// </summary>
        All,

        /// <summary>
        /// Indicates that only public repositories should be returned.
        /// </summary>
        Public,

        /// <summary>
        /// Indicates that only public repositories should be returned.
        /// </summary>
        Private,

        /// <summary>
        /// Indicates that only internal repositories should be returned. This option only applies to GitHub AE.
        /// </summary>
        Internal

    }

}