namespace Skybrud.Social.GitHub.Models.Teams {

    /// <summary>
    /// Used to describe a team's privacy level.
    /// </summary>
    public enum GitHubTeamPrivacy {
        
        /// <summary>
        /// Only visible to organization owners and members of the team.
        /// </summary>
        Secret,

        /// <summary>
        /// Visible to all members of the organization.
        /// </summary>
        Closed

    }

}