namespace Skybrud.Social.GitHub.Options.Organizations.Members {
    
    /// <summary>
    /// Enum class representing the role the returned members should match.
    /// </summary>
    public enum GitHubMemberRole {

        /// <summary>
        /// All members of the organization, regardless of role.
        /// </summary>
        All,

        /// <summary>
        /// Organization owners.
        /// </summary>
        Admin,

        /// <summary>
        /// Non-owner organization members.
        /// </summary>
        Member

    }

}