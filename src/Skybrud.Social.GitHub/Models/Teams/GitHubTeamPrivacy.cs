using Skybrud.Social.GitHub.Constants;

namespace Skybrud.Social.GitHub.Models.Teams {

    /// <summary>
    /// Used to describe a team's privacy level.
    /// </summary>
    public enum GitHubTeamPrivacy {

        /// <summary>
        /// Indicates a privacy level could not be recognized by this package.
        /// </summary>
        Unrecognized = GitHubConstants.Unrecognized,

        /// <summary>
        /// For a request, this option may be used to indicate that the privacy level isn't specified, leaving it up to the default value of the API.
        ///
        /// For a response, this value indicates that the privacy level was not part of the JSON body in the response.
        /// </summary>
        Unspecified = GitHubConstants.Unspecified,

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