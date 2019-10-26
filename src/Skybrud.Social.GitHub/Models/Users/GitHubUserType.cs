namespace Skybrud.Social.GitHub.Models.Users {
    
    /// <summary>
    /// Enum class specifying the type of a GitHub user.
    /// </summary>
    public enum GitHubUserType {

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