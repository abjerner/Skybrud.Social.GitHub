using Skybrud.Social.GitHub.Constants;

namespace Skybrud.Social.GitHub.Models.Users {
    
    /// <summary>
    /// Enum class specifying the type of a GitHub user.
    /// </summary>
    public enum GitHubUserType {

        /// <summary>
        /// Indicates a user type could not be recognized by this package.
        /// </summary>
        Unrecognized = GitHubConstants.Unrecognized,

        /// <summary>
        /// This means that the property was missing in the JSON returned by the GitHub API.
        /// </summary>
        Unspecified = GitHubConstants.Unspecified,

        /// <summary>
        /// Indicates that a user is a normal GitHub user.
        /// </summary>
        User,

        /// <summary>
        /// Indicates that a user is an GitHub organisation.
        /// </summary>
        Organization,

        /// <summary>
        /// Indicates that the user is a bot.
        /// </summary>
        Bot
    
    }

}