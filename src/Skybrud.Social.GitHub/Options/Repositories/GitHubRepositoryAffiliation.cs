using System;

namespace Skybrud.Social.GitHub.Options.Repositories {

    /// <summary>
    /// Enum class indicating the affiliation the returned repositories should match.
    /// </summary>
    [Flags]
    public enum GitHubRepositoryAffiliation {

        /// <summary>
        /// Indicates that all repositories should be returned.
        /// </summary>
        All = 0,

        /// <summary>
        /// Indicates that only repositories where the authenticated user is the owner should be returned.
        /// </summary>
        Owner = 1,

        /// <summary>
        /// Indicates that only repositories where the authenticated user is a collaborator should be returned.
        /// </summary>
        Collaborator = 2,

        /// <summary>
        /// Indicates that only repositories where the authenticated user is an organization member should be returned.
        /// </summary>
        OrganizationMember = 4

    }

}