namespace Skybrud.Social.GitHub.Options.Organizations.Members {
    
    /// <summary>
    /// Enum class representing a filer the returned members should match.
    /// </summary>
    public enum GitHubMemberFilter  {

        /// <summary>
        /// Indicates that all members the authenticated user can see should be returned.
        /// </summary>
        All,

        /// <summary>
        /// Indicates that only members without two-factor authentication enabled should be returned. Available for organization owners.
        /// </summary>
        TwoFactorDisabled

    }

}